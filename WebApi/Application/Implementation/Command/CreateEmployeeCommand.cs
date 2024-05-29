
using Application.Interface;
using Domain.entity;
using MediatR;

namespace Application.Implementation.Command
{
    public class CreateEmployeeCommand : IRequest<Guid>
    {
        
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
        public string AreaCode { get; set; }= string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string IsAdmin {  get; set; } = string.Empty;


        public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeCommand, Guid>
        {

            private readonly IApplicationDbContext _context;

            public CreateEmployeeHandler(IApplicationDbContext context)
            {
                
                _context = context;
            }
            public async Task<Guid> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
            {
          
                var employee = new Employee();
                employee.FirstName = request.FirstName;
                employee.LastName = request.LastName;
                employee.UserName = request.UserName;
                employee.PassWord = request.PassWord;
                employee.AreaCode = request.AreaCode;
                employee.Street = request.Street;   
                employee.City = request.City;
                employee.IsAdmin = request.IsAdmin;
                await _context.Employee.AddAsync(employee);
                await _context.SaveChangesAsync();

               
                return employee.Id;
            }
        }

    }
}
