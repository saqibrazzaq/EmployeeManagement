## Steps
- Add extension method for cors
- Add projects for NLog
  - Contracts - contains interfaces
  - LoggerService - contains logging using NLog
- Add projects for service and repositories
  - Contracts - Base and user repository interfaces
  - Entities - Data model classes for creating database
  - Repository - Base and user repository classes, seed data
  - Service.Contracts - ServiceManager and user service interfaces
  - Service - ServiceManager and user service classes
- Add Get controller
  - Employees.Presentation - Controllers for endpoints
  - GetAllCompanies() method in repository, service and controller
  - Shared project with DataTransferObjects folder
  - CompanyDto
  - AutoMapper - Map Company to CompanyDto
- Global exception handler
  - No try catch blocks needed anywhere
  - All exceptions will be handled and logged using middleware
- All employees and single employee within a company
- csv formatter for companies
- Create company
  - Single company
  - Single company with new employees
  - Multiple companies
  - Get multiple companies
- Delete company
  - Delete single company
  - Delete cascade company with all employees
- Update company
  - Update single company
  - Update with track changes ON
  - No need to call Repository.Update because it updates all columns
  - Get data with track changes ON
  - Move updates from Dto to Entity using AutoMapper
  - Call repository.save(), it will only update which are CHANGED (with track changes)
- Validation
  - Add validation in create and update dto classes
  - Add validation code in ManipulateDto and make it abstract
  - Create and Update Dtos inherit ManipulationDto, so that same validation is at central
- ActionFilters
  - Create new class for checking null Dto and validation
  - Use ServiceFilter attribute in controller for null and model validation
  - No need to check null and if (ModelState.IsValid) in any controller
- Pagination
  - Add PagedList with MetaData
  - MetaData contains page number, size, next, previous, total count
  - Add RequestParameters class with current page and page size with defaults
  - Repository method returns PagedList instead of ienumerable
  - Service method returns IEnumerable of dto and Metadata
  - Controller returns IEnumerable of dto and adds metadata in X-Pagination header
  - Add X-Pagination in cors config
- Filtering
  - Add filtering in GetEmployees class. MinAge and MaxAge
  - Check valid age range in service
  - Add search in repository
- Searching
  - Extend EmployeesRepository class and add extension methods for Filter and Search
  - string lower case conversions for search done in extension methods
  - where condition applied in extension methods
- Sorting
  - Add Sort method in EmployeeRepositoryExtension class
  - Create a generic method in OrderQueryBuilder.CreateOrderQuery
  - This generic method can sort generate order query for any entity
- DataShaper
  - Add DataShaper class, which uses Reflection API
  - Pass fields comma separated string in query string param
  - Convert fields to Properties and fetch properties from Dto which are in params
- Authentication
  - Use EFCore Identity
  - RepositoryContext uses IdentityDbContext<User>
  - Create User in entities, inherits from IdentityUser
  - Add extension method to services.AddIdentity, pass user and role
  - Add UserForRegistrationDto and UserForAuthenticationDto records
  - RegisterUser takes user, password, name, email, phone and registers user
  - AuthenticateUser takes user and password, validates from db using user manager
  - if login successful, generate signed token and send to the client
  - Add [Authorize] to controllers which need authentication and roles
  - Test with different users with different roles
