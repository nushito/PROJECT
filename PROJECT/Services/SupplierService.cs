
using PROJECT.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly ApplicationDbContext dbContext;

        public SupplierService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ICollection<string> GetSuppliers()
        {
            return dbContext
                 .Suppliers
                 .Select(a => a.Name)
                 .ToList();

        }
    }
}
