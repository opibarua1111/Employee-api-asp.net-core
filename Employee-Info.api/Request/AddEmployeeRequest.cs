using System.ComponentModel.DataAnnotations;

namespace Employee_Info.api.Request
{
    public class AddEmployeeRequest
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
