
using PROJECT.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Data.Models
{
    using static ConstantsValidation;
    public class Invoice
    {
        public Invoice()
        {
            Products = new HashSet<Product>();
        }
        public int Id { get; init; }
        [Required]
        [StringLength(InvoiceNumber)]
        public string Number { get; set; }
        [Required]
        public DateTime Date { get; set; }
 
        [Required]
        public MyCompany Seller { get; set; }
        [Required]
        public Customer Client { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}