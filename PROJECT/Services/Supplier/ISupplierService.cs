
using PROJECT.Data.Models;
using PROJECT.Services.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Services
{
    public interface ISupplierService
    {
        public ICollection<AllSuppliers> GetSuppliers();

       
    }
}
