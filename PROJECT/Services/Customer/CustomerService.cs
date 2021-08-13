using PROJECT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Services.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext dbContext;
        public CustomerService(ApplicationDbContext dbContex)
        {
            this.dbContext = dbContex;
        }
        public IEnumerable<string> GetCustomers()
        {
            return dbContext.Clients.Select(a => a.Name).ToList();
        }
    }
}
