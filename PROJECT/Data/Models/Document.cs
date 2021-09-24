using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PROJECT.Data;

namespace PROJECT.Data.Models
{
    using static ConstantsValidation;
    public class Document
    {
        public Document()
        {
            Products = new HashSet<Product>();
        }
     
        public int Id { get; init; }
        public string Type { get; set; }
        [Required]
        [MaxLength(InvoiceNumber)]
        public int Number { get; set; }
        [Required]
        public DateTime Date { get; set; }
       
        public int ClientId { get; set; }
        public Customer Client { get; set; }
        public int MyCompanyId { get; set; }
        public MyCompany Seller { get; set; }
        public decimal Amount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
        public int VatParcent { get; set; }
        public ICollection<Product> Products { get; set; }


    }
}