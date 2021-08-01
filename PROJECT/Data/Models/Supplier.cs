
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InvoiceAndStockModels
{
    public class Supplier
    {
        public Supplier()
        {
            Products = new HashSet<Product>();
            BankDetails = new List<BankDetails>();
         }
     
        public int Id { get; init; }
        [Required]
        public string Name { get; set; }
        [Required]
        
        public string Eik { get; set; }
        [Required]
        
        public string VAT { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public BankDetails BankDetail { get; set; }
        public ICollection<BankDetails> BankDetails { get; init; }
        public Address SupplierAddress { get; set; }

        public string RepresentativePerson { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }
}