
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PROJECT.Models.Reports
{
    public class ProductsAvailability
    {
       
        public int Id { get; init; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Size { get; set; }
        [Required]
        public string Grade { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public IEnumerable<string> Suppliers { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public IEnumerable<string> Customers { get; set; }
        public IEnumerable<string> Descriptions { get; set; }
        public IEnumerable<string> Sizes { get; set; }
        public IEnumerable<string> Grades { get; set; }
        public ICollection<ProductsAvailability> Products { get; set; }
    }
}
