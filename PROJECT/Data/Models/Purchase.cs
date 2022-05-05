using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Data.Models 
{ 
    public class Purchase
    {
        public Purchase()
        {
            Products = new HashSet<ProductPurchase>();
        }
     
        public int Id { get; init; }
        [Required]
        public int SupplierId { get; set; }
        [Required]
        public Supplier Supplier { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public ICollection<ProductPurchase> Products { get; set; }
    }
}
