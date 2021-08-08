using System.Collections.Generic;
using System.Linq;
using PROJECT.Data;
using PROJECT.Data.Models;

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

        public ICollection<string> GetDescription()
        {
            return dbContext.Products
                .Select(x => x.Description)
                .ToList();
        }
    

        public ICollection<string> GetGrade()
        {
            return dbContext.Products
                .Select(x => x.Grade)
                .ToList();
        }
    
        public ICollection<string> GetSize()
        {
            return dbContext.Products
                .Select(x => x.Size)                 
                .ToList();
        }
    }
}




   
