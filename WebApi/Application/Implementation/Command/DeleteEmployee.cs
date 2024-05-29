
using Application.Interface;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Implementation.Command
{
    public  class DeleteEmployee : IRequest<Guid>
    {
        public Guid Id { get; set; }

        public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployee, Guid>
        {
            private readonly IApplicationDbContext _context;
            public DeleteEmployeeHandler(IApplicationDbContext dbContext) { 
            
                _context = dbContext;
            }
            public async Task<Guid> Handle(DeleteEmployee request, CancellationToken cancellationToken)
            {
                var result = await _context.Employee.Where(x=>x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
                if (result == null)
                {
                    return default;
                }
                _context.Employee.Remove(result);
                await _context.SaveChangesAsync();

                return result.Id;
               
            }
        }
    }
   
}
