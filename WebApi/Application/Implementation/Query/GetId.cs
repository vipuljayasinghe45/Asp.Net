
using Application.Interface;
using Domain.entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Implementation.Query
{
    public class GetId:IRequest<Employee>
    {
        public Guid Id { get; set; }
        public GetId(Guid id)
        {
            this.Id = id;
        }
        public class GetIdhandler : IRequestHandler<GetId, Employee>
        {
            private readonly IApplicationDbContext _context;

            public GetIdhandler(IApplicationDbContext context)
            {
                this._context = context;
            }
            public async Task<Employee> Handle(GetId request, CancellationToken cancellationToken)
            {
                var employee = await _context.Employee.Where(x=> x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
                if (employee == null)
                {
                    throw new Exception("Employee Id not found");
                } 
                else
                {
                    return employee;
                }

            }
        }
    }
}
