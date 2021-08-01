using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PROJECT.Data;

namespace InvoiceAndStockModels
{
    using static ConstantsValidation;
    public class Document
    {
        public Document()
        {
            Products = new HashSet<Product>();
        }
     
        public int Id { get; init; }
        [Required]
        [StringLength(InvoiceNumber)]
        public string Number { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public Supplier Supplier { get; set; }
        public Customer Client { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}