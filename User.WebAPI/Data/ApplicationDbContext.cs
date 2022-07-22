using Microsoft.EntityFrameworkCore;
using User.Domain.Models;

namespace User.WebAPI.Data
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}
