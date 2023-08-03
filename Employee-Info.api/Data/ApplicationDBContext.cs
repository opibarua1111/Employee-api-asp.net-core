using Employee_Info.api.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Info.api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
    }
}
