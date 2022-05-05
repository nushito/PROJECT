
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Models.Purchases
{
    public class ProductsPurchase
    {
        public ProductsPurchase()
        {
            PurchaseProducts = new List<PurchaseProductViewModel>();
        }
     
        public int PurchaseId { get; set; }
      
        public ICollection<PurchaseProductViewModel> PurchaseProducts { get; set; }


    }
}
