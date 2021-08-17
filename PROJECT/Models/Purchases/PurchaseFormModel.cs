
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
     
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string InvoiceNumber { get; set; }
        public string Date { get; set; }
       
        public int Pieces { get; set; }
        
        public PurchaseProductFormModel PurchaseProductFormModel { get; set; }
        
        public ICollection<AllSuppliers> Suppliers { get; set; }
        public ICollection<PurchaseProductFormModel> PurchaseProducts { get; set; } 
        
    }
}
