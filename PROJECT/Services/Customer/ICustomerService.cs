using System.Collections.Generic;

namespace PROJECT.Services.Customer
{
    public interface ICustomerService
    {
        public IEnumerable<string> GetCustomers();
    }
}
