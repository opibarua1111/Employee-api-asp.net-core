using Employee_Info.api.Models;

namespace Employee_Info.api.Response
{
    public class EmployeeResponse :EmployeeBaseResponse
    {
        public Employee Employee { get; internal set; }
    }
}
