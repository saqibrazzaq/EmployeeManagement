using Employees.Presentation.ActionFilters;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Employees.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;
        public EmployeesController(IServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployeesForCompany(
            Guid companyId, [FromQuery] EmployeeParameters employeeParameters)
        {
            var pagedResult = await _service.EmployeeService.GetEmployeesAsync(
                companyId, employeeParameters, trackChanges: false);
            Response.Headers.Add("X-Pagination", 
                JsonSerializer.Serialize(pagedResult.metaData));
            return Ok(pagedResult.employees);
        }

        [HttpGet("{id:guid}", Name = "GetEmployeeForCompany")]
        public async Task<IActionResult> GetEmployee(Guid companyId, Guid employeeId)
        {
            var employee = await _service.EmployeeService.GetEmployeeAsync(
                companyId, trackChanges: false, employeeId: employeeId);
            return Ok(employee);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> CreateEmployeeForCompany(Guid companyId, 
            [FromBody] EmployeeForCreationDto employee)
        {
            var employeeToReturn = await _service.EmployeeService
                .CreateEmployeeForCompanyAsync(companyId, employee, trackChanges: false);

            return CreatedAtRoute("GetEmployeeForCompany",
                new { companyId, id = employeeToReturn.Id },
                employeeToReturn);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteEmployeeForCompany(Guid companyId, Guid id)
        {
            await _service.EmployeeService.DeleteEmployeeForCompanyAsync(companyId, id, trackChanges: false);
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        [ServiceFilter(typeof (ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateEmployeeForCompany(Guid companyId, Guid id,
            [FromBody] EmployeeForUpdateDto employee)
        {
            await _service.EmployeeService.UpdateEmployeeForCompanyAsync(companyId, id, employee,
                trackChanges: false, empTrackChanges: true);

            return NoContent();
        }
    }
}
