using Employee_Info.api.Data;
using Employee_Info.api.Interfaces;
using Employee_Info.api.Models;
using Employee_Info.api.Request;
using Employee_Info.api.Response;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace Employee_Info.api.Services
{
    public class EmployeeService : IEmployeeService
    {
        public readonly ApplicationDBContext _context;
        public EmployeeService(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<EmployeeResponse> CreateEmployeeAsync(AddEmployeeRequest addEmployeeRequest)
        {
            var employee = new Employee()
            {
                Id = Guid.NewGuid(),
                FirstName = addEmployeeRequest.FirstName,
                LastName = addEmployeeRequest.LastName,
                FullName = addEmployeeRequest.FirstName + " " + addEmployeeRequest.LastName,
                Salary = addEmployeeRequest.Salary,
                Age = addEmployeeRequest.Age,
                Designation = addEmployeeRequest.Designation,
                Description = addEmployeeRequest.Description,
                Status = "active",
                CeratedAt = DateTime.Now.ToString("ddd, MMM dd yyyy HH:mm:ss 'GMT'K '(Bangladesh Standard Time)'"),
                ModefiedAt = DateTime.Now.ToString("ddd, MMM dd yyyy HH:mm:ss 'GMT'K '(Bangladesh Standard Time)'"),
            };

            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();

            return new EmployeeResponse { Success = true, Employee = employee };
        }
        public async Task<EmployeeResponse> GetEmployee(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);

            return new EmployeeResponse { Success = true, Employee = employee };
        }

        public async Task<EmployeeResponse> UpdateEmployeeAsync(Guid id, AddEmployeeRequest updateEmployeeRequest)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                 return new EmployeeResponse { Success = false };
            }
            employee.FirstName = updateEmployeeRequest.FirstName;
            employee.LastName = updateEmployeeRequest.LastName;
            employee.FullName = updateEmployeeRequest.FirstName + updateEmployeeRequest.LastName;
            employee.Salary = updateEmployeeRequest.Salary;
            employee.Age = updateEmployeeRequest.Age;
            employee.Description = updateEmployeeRequest.Description;
            employee.Designation = updateEmployeeRequest.Designation;
            employee.ModefiedAt = DateTime.Now.ToString("ddd, MMM dd yyyy HH:mm:ss 'GMT'K '(Bangladesh Standard Time)'");

            await _context.SaveChangesAsync();
            return new EmployeeResponse { Success = true, Employee = employee };

        }

        public async Task<EmployeeResponse> DeleteEmployeeAsync(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null)
            {
                return new EmployeeResponse { Success = false };
            }
            employee.Status = "pending";
            await _context.SaveChangesAsync();
            return new EmployeeResponse { Success = true, Employee = employee };
        }
    }
}
