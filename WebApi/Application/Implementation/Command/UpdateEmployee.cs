
using Application.Interface;
using Domain.entity;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Implementation.Command
{
    public  class UpdateEmeployee : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
        public string AreaCode { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string IsAdmin { get; set; } = string.Empty;

        public class UpdateEmployeeCommmandHandler : IRequestHandler<UpdateEmeployee, Guid>
        {
           private readonly IApplicationDbContext _context;
            public UpdateEmployeeCommmandHandler(IApplicationDbContext context) 
            {
                _context = context;
                        
            }
            public async Task<Guid> Handle(UpdateEmeployee request, CancellationToken cancellationToken)
            {
                var Employee = await _context.Employee.Where(x=>x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);
                
                if (Employee != null)
                {
                    Employee.FirstName = request.FirstName;
                    Employee.LastName = request.LastName;
                    Employee.UserName = request.UserName;
                    Employee.PassWord = request.PassWord;
                    Employee.AreaCode = request.AreaCode;
                    Employee.Street = request.Street;
                    Employee.City = request.City;
                    Employee.IsAdmin = request.IsAdmin;

                    
                    await _context.SaveChangesAsync();
                    return Employee.Id;
                }

                return default;


            }
        }
    }
}
