using Microsoft.EntityFrameworkCore;
using ProCodeGuide.Samples.AsyncWebAPI.DBEntities;
using ProCodeGuide.Samples.AsyncWebAPI.Interfaces;

namespace ProCodeGuide.Samples.AsyncWebAPI.DBContext
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EmployeeEntity>? Employees { get; set; }
        public new async Task<int> SaveChanges()
        {
            return await base.SaveChangesAsync();
        }
    }
}
