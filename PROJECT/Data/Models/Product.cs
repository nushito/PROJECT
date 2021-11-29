using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Data.Models
{
   public class Product
    {
        public Product()
        {
            Customers = new HashSet<Customer>();
            ProductSpecifications = new HashSet<ProductSpecification>();
            Orders = new HashSet<Order>();
            Purchases = new HashSet<ProductPurchase>();
        }
        
        public int Id { get; init; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Grade { get; set; }
        public decimal Quantity { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public ICollection<ProductSpecification> ProductSpecifications { get; set; }
        public ICollection<ProductPurchase> Purchases { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<Customer> Customers { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
