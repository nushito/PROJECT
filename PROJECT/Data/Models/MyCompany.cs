using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using PROJECT.Data;

namespace PROJECT.Data.Models
{
    using static ConstantsValidation;
    public class MyCompany 
    {
        public MyCompany()
        {
           
            BankDetails = new HashSet<BankDetails>();
            Currencies = new HashSet<Currency>();
            Invoices = new HashSet<Invoice>();
            Orders = new HashSet<Order>();

        }
        
        public int Id { get; init; } 
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(EikLength, MinimumLength = EikLength, ErrorMessage = "EIK number should be 9 symbols long.")]
        public string Eik { get; set; }

        [Required]
        [StringLength(VatLength, MinimumLength = VatLength, ErrorMessage = "VAT number should be 11 symbols long.")]
        public string VAT { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        public string RepresentativePerson { get; set; }
        public string UserId { get; set; }

        public IEnumerable<Order> Orders { get; set; }
        public ISet<Currency> Currencies { get; set; }

        public ISet<BankDetails> BankDetails { get; set; }

      public IEnumerable<Invoice> Invoices { get; set; }
        
    

    }
}
