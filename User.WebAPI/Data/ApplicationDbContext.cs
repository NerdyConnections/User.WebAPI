using Microsoft.EntityFrameworkCore;
using User.Domain.Models;

namespace User.WebAPI.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
       

        public DbSet<UserModel> Users { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
