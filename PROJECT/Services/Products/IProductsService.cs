using PROJECT.Models.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Services.Products
{
    public interface IProductsService
    {
        public int Add(int id,
            string description,
            string size,
            string grade);

        public ICollection<string> GetDescription();
        public ICollection<string> GetSize();
        public ICollection<string> GetGrade();

    }
}
