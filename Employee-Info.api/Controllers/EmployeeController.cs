using Employee_Info.api.Data;
using Employee_Info.api.Interfaces;
using Employee_Info.api.Models;
using Employee_Info.api.Request;
using Employee_Info.api.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Info.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly ApplicationDBContext _context;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(ApplicationDBContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }
        [HttpGet]
        public async Task<ActionResult> GetAllEmployee([FromQuery] EmployeeQueryParameters queryParameters)
        {
            try {
                IQueryable<Employee> employeesQuery = _context.Employees;

                if (queryParameters.MinAge != null)
                {
                    employeesQuery = employeesQuery.Where(
                        p => p.Age >= queryParameters.MinAge.Value);
                }
                if (queryParameters.MaxAge != null)
                {
                    employeesQuery = employeesQuery.Where(
                        p => p.Age <= queryParameters.MaxAge.Value);
                }
                if (!string.IsNullOrEmpty(queryParameters.Designation))
                {
                    employeesQuery = employeesQuery.Where(
                        p => p.Designation.ToLower().Contains(queryParameters.Designation.ToLower()));
                }
                if (!string.IsNullOrEmpty(queryParameters.SearchName))
                {
                    employeesQuery = employeesQuery.Where(
                        p => p.FullName.ToLower().Contains(queryParameters.SearchName.ToLower()));
                }

                employeesQuery = employeesQuery.Where(
                        p => p.Status == "active");

                employeesQuery = employeesQuery
                    .Skip(queryParameters.Size * (queryParameters.Page - 1))
                    .Take(queryParameters.Size);

                var employees = await employeesQuery.ToListAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<ActionResult> AddEmployee([FromBody] AddEmployeeRequest addEmployeeRequest)
        {
            try {
                var employeeResponse = await _employeeService.CreateEmployeeAsync(addEmployeeRequest);

                if (!employeeResponse.Success)
                {
                    return NotFound(employeeResponse);
                }

                return Ok("Employee added Successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult> GetEmployee([FromRoute] Guid id)
        {
            try
            {
                var employeeResponse = await _employeeService.GetEmployee(id);
                if (!employeeResponse.Success)
                {
                    return NotFound(employeeResponse);
                }
                return Ok(employeeResponse.Employee);
            }
            catch {
                return BadRequest();
            }
            
        }
        [HttpPost("editEmployee/{id}")]
        public async Task<ActionResult> UpdateEmployee([FromRoute] Guid id, [FromForm] AddEmployeeRequest updateEmployeeRequest)
        {
            try
            {
                var employeeResponse = await _employeeService.UpdateEmployeeAsync(id, updateEmployeeRequest);
                if (!employeeResponse.Success)
                {
                    return NotFound(employeeResponse);
                }
                return Ok("Employee Updated Successfully");

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           
        }
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<ActionResult> DeleteEmployee([FromRoute] Guid id)
        {
            try
            {
                var employeeResponse = await _employeeService.DeleteEmployeeAsync(id);
                if (!employeeResponse.Success)
                {
                    return NotFound(employeeResponse);
                }
                return Ok("Employee Deleted Successfully");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
