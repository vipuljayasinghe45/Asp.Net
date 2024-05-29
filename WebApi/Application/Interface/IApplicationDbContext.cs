
using Domain.entity;
using Microsoft.EntityFrameworkCore;

namespace Application.Interface
{
    public interface IApplicationDbContext

    {
        DbSet<Employee> Employee { get; set; }
        Task<int> SaveChangesAsync();
    }
}
