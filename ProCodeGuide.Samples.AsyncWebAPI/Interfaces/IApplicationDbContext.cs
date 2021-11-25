using Microsoft.EntityFrameworkCore;
using ProCodeGuide.Samples.AsyncWebAPI.DBEntities;

namespace ProCodeGuide.Samples.AsyncWebAPI.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<EmployeeEntity>? Employees { get; set; }
        Task<int> SaveChanges();
    }
}
