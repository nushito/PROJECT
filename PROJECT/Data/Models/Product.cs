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
        }
        
        public int Id { get; init; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Grade { get; set; }       
        [Required]
        public string Unit { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        public decimal TransportCost { get; set; }
        public decimal TerminalCharges { get; set; }
        public decimal CustomsExpenses { get; set; }
        public decimal Duty { get; set; }
        public decimal BankExpenses { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
        public ICollection<Customer> Customers { get; set; }
    }
}
