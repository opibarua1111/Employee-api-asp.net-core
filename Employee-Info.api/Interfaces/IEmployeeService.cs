using Employee_Info.api.Request;
using Employee_Info.api.Response;

namespace Employee_Info.api.Interfaces
{
    public interface IEmployeeService
    {
        Task<EmployeeResponse> CreateEmployeeAsync(AddEmployeeRequest addEmployeeRequest);
        Task<EmployeeResponse> UpdateEmployeeAsync(Guid id, AddEmployeeRequest updateEmployeeRequest);
        Task<EmployeeResponse> DeleteEmployeeAsync(Guid id);
        Task<EmployeeResponse> GetEmployee(Guid id); 
    }
}
