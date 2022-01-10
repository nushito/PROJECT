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
            string grade,
            string name
           )
        {
            var supplier = dbContext.Suppliers
                .Where(a => a.Name.ToLower() == name.ToLower())
                .FirstOrDefault();

            var newProduct = new Product
            {
                Id = id,
                Description = description,
                Size = size,
                Grade = grade,
                SupplierId = supplier.Id
            };

            this.dbContext.Products.Add(newProduct);
            this.dbContext.SaveChanges();

            return newProduct.Id;
        }

        public ICollection<string> GetDescription()
        {
            return dbContext.Products
                .Select(x =>x.Description).ToList();
        }
    

        public ICollection<string> GetGrade()
        {
            return dbContext.Products
                .Select(x => 
                 x.Grade).ToList();
        }
    
        public ICollection<string> GetSize()
        {
            return dbContext.Products
                .Select(x => x.Size)              
                .ToList();
        }
    }
}




   
