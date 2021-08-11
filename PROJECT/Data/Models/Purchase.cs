using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Data.Models 
{ 
    public class Purchase
    {
     
        public int Id { get; init; }
        public int SipplierId { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
