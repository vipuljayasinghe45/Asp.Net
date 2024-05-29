
using Domain.common;

namespace Domain.entity
{
    public class Employee : MarketingCommonDetails
    {
      
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string PassWord { get; set; } = string.Empty;
        public string IsAdmin {  get; set; } = string.Empty;
        
        

       
    }
}
