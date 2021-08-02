
using System.Collections.Generic;

namespace PROJECT.Models.Purchases
{
    public class PurchaseFormModel
    {
        public PurchaseFormModel()
        {
            Suppliers = new List<string>();
        }
        public string SupplierName { get; set; }
        public ICollection<string> Suppliers { get; set; }
        public string InvoiceNumber { get; set; }
        public string Date { get; set; }
      //  public IEnumerable<PurchaseProductFormModel> purchaseProducts { get; set; } = new List<PurchaseProductFormModel>();
        
    }
}
