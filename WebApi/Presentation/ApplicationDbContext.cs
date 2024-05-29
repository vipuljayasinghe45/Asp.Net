

using Application.Interface;
using Domain.entity;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    { 
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Employee> Employee { get ; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }

}
    

