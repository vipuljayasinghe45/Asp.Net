using Application.Interface;
using Domain.entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Implementation.Query
{
    public class GetAllEmployeeQuery:IRequest<IEnumerable<Employee>>
    {
        internal class GetAllEmployeeQueryHandler : IRequestHandler<GetAllEmployeeQuery, IEnumerable<Employee>>
        {
            private readonly IApplicationDbContext _context;
            public GetAllEmployeeQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<IEnumerable<Employee>> Handle(GetAllEmployeeQuery request, CancellationToken cancellationToken)
            {
               var result = await _context.Employee.ToListAsync(cancellationToken);
                return result;
            }
        }
    }
}
