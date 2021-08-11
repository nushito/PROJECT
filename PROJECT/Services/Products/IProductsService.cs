using PROJECT.Models.Purchases;
using PROJECT.Services.Products.Models;
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

        public ICollection<DescriptionListModel> GetDescription();
        public ICollection<SizeListModel> GetSize();
        public ICollection<GradeListModel> GetGrade();

    }
}
