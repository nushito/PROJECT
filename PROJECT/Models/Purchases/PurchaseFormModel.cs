
using System.Collections.Generic;

namespace PROJECT.Models.Purchases
{
    public class PurchaseFormModel
    {
        public PurchaseFormModel()
        {
            Suppliers = new List<string>();
            purchaseProducts = new HashSet<PurchaseProductFormModel>();
        }
        public string SupplierName { get; set; }
        public ICollection<string> Suppliers { get; set; }
        public string InvoiceNumber { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Grade { get; set; }
        public ICollection<string> Descriptions { get; set; }
        public ICollection<string> Sizes { get; set; }
        public ICollection<string> Grades { get; set; }
        public ICollection<PurchaseProductFormModel> purchaseProducts { get; set; } 
        
    }
}
