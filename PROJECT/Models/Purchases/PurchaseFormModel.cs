
using PROJECT.Data.Models;
using PROJECT.Services.Products.Models;
using PROJECT.Services.Supplier;
using System.Collections.Generic;

namespace PROJECT.Models.Purchases
{
    public class PurchaseFormModel
    {
        public PurchaseFormModel()
        {
               
        }

        public int Id { get; init; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Number { get; set; }
        public string Date { get; set; }
       
        public int Pieces { get; set; }
        
       // public PurchaseProductFormModel PurchaseProductFormModel { get; set; }
        public ICollection<PurchaseProductViewModel> PurchaseProductViewModel { get; set; }

        public ICollection<AllSuppliers> Suppliers { get; set; }
        public ICollection<ProductSpecificationFormModel> ProductsSpecifications { get; set; } 
        
    }
}
