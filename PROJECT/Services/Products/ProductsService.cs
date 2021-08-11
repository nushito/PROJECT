using System.Collections.Generic;
using System.Linq;
using PROJECT.Data;
using PROJECT.Data.Models;
using PROJECT.Services.Products.Models;

namespace PROJECT.Services.Products
{
    public class ProductsService : IProductsService
    {
        private readonly ApplicationDbContext dbContext;
        public ProductsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Add(
            int id,
            string description,
            string size,
            string grade
           )
        {
            var newProduct = new Product
            {
                Id = id,
                Description = description,
                Size = size,
                Grade = grade,
            };

            this.dbContext.Products.Add(newProduct);
            this.dbContext.SaveChanges();

            return newProduct.Id;
        }

        public ICollection<DescriptionListModel> GetDescription()
        {
            return dbContext.Products
                .Select(x => new DescriptionListModel 
                {
                    Id = x.Id, 
                    Name = x.Description
                })
                .ToList();
        }
    

        public ICollection<GradeListModel> GetGrade()
        {
            return dbContext.Products
                .Select(x => 
                new GradeListModel
                {
                    Id = x.Id,
                    Name = x.Grade
                })
                .ToList();
        }
    
        public ICollection<SizeListModel> GetSize()
        {
            return dbContext.Products
                .Select(x => new SizeListModel 
                { 
                    Id = x.Id,
                    Name = x.Size
                } )                 
                .ToList();
        }
    }
}




   
