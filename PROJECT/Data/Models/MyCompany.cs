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
        private readonly IDictionary<Currency, BankDetails> bankDetailsList = null;
        public MyCompany()
        {
            //BankDetails = new Dictionary<Currency,BankDetails>();
            BankDetails = new HashSet<BankDetails>();
            Currencies = new HashSet<Currency>();
            Invoices = new List<Document>();

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

      public IEnumerable<Document> Invoices { get; set; }
        [NotMapped]
      public IDictionary<Currency, BankDetails> BankDetailsList { get; set; }

    }
}
