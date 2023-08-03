using System.ComponentModel.DataAnnotations;

namespace Employee_Info.api.Models
{
    public class Employee
    {
        public Guid Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string FullName { get; set; }
        [Required]
        public int Salary { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Designation { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public string CeratedAt { get; set; }
        public string? ModefiedAt { get; set; }
    }
}
