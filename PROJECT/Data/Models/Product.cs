using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Data.Models
{
   public class Product
    {
        public Product()
        {
            Suppliers = new HashSet<Supplier>();
            Customers = new HashSet<Customer>();
            ProductSpecifications = new HashSet<ProductSpecification>();
        }
        
        public int Id { get; init; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Grade { get; set; }
        public decimal Quantity { get; set; }
        [Required]
        public ICollection<ProductSpecification> ProductSpecifications { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}
