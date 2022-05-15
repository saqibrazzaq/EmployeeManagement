using AutoMapper;
using Contracts;
using Entities;
using Entities.Exceptions;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public EmployeeService(IRepositoryManager repository, 
            ILoggerManager logger,
            IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> CreateEmployeeForCompanyAsync(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var employeeEntity = _mapper.Map<Employee>(employeeForCreation);

            _repository.Employee.CreateEmployeeForCompany(
                companyId, employeeEntity);
            await _repository.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);
            return employeeToReturn;
        }

        public async Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var employeeForCompany = await GetEmployeeAndCheckIfItExists(
                companyId, id, trackChanges);

            _repository.Employee.DeleteEmployee(employeeForCompany);
            await _repository.SaveAsync();
        }

        public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid employeeId, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var employee = await GetEmployeeAndCheckIfItExists(
                companyId, employeeId, trackChanges);

            var employeeDto = _mapper.Map<EmployeeDto>(employee);
            return employeeDto;
        }

        public async Task<(IEnumerable<EmployeeDto> employees, MetaData metaData)> 
            GetEmployeesAsync(
            Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
        {
            if (!employeeParameters.ValidAgeRange)
                throw new MaxAgeRangeBadRequestException();

            await CheckIfCompanyExists(companyId, trackChanges);

            var employeesWithMetaData = await _repository.Employee.GetEmployeesAsync(
                companyId, employeeParameters, trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);
            return (employees: employeesDto, metaData: employeesWithMetaData.MetaData);
        }

        public async Task UpdateEmployeeForCompanyAsync(Guid companyId, Guid id, 
            EmployeeForUpdateDto employeeForUpdate, bool trackChanges, bool empTrackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var employeeEntity = await GetEmployeeAndCheckIfItExists(
                companyId, id, empTrackChanges);

            // Move changes from Dto to Entity
            _mapper.Map(employeeForUpdate, employeeEntity);
            // Save in repository, without calling Repository.Update
            // It works because of trackChanges
            // GetEmployee method returns entity, with trackChanges ON for employee
            // If we call Save() method of repository, it automatically saves tracked changes
            // If we call Repository.Update(), it will update the whole record
            // Just Get entity, update entity with trackChanges, Save,
            // it will only update the modified columns
            await _repository.SaveAsync();
        }

        private async Task<Company> CheckIfCompanyExists(Guid companyId, bool trackChanges)
        {
            var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges);
            if (company == null)
                throw new CompanyNotFoundException(companyId);
            return company;
        }

        private async Task<Employee> GetEmployeeAndCheckIfItExists(
            Guid companyId, Guid id, bool trackChanges)
        {
            var employeeEntity = await _repository.Employee.GetEmployeeAsync(
                companyId, id, trackChanges);
            if (employeeEntity is null)
                throw new EmployeeNotFoundException(id);
            return employeeEntity;
        }
    }
}
