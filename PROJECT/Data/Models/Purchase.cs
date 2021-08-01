using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceAndStockModels
{
    public class Purchase
    {
     
        public int Id { get; init; }
        public Supplier Supplier { get; set; }
        public DateTime Date { get; set; }
        public string InvoiceNumber { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
