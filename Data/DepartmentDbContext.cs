using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApi.Data
{
    public class DepartmentDbContext : DbContext
    {
        public DepartmentDbContext(DbContextOptions<DepartmentDbContext> options)
            : base(options)
        {

        }
        public DbSet<Department> Departments { get; set; }
    }
}
