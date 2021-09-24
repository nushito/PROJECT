
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
        [MaxLength(InvoiceNumber)]
        public int Number { get; set; }
        [Required]
        public DateTime Date { get; set; }
 
        [Required]
        public MyCompany Seller { get; set; }
        [Required]
        public Customer Client { get; set; }
        public ICollection<Product> Products { get; set; }
        public decimal Amount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public int VatParcent { get; set; }
    }
}