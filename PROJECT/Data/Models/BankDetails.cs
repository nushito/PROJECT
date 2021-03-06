
using PROJECT.Data;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PROJECT.Data.Models
{
    using static ConstantsValidation;
    public class BankDetails
    {
     
        public int Id { get; init; }
        public int CurrencyId { get; set; }
        [Required]
        public Currency Currency { get; init; }
        [Required]
        public string BankName { get; set; }

        [StringLength(IbanLength,ErrorMessage ="Your IBAN is invalid!")]
        public string Iban { get; set; }
        [Required]
        public string Swift { get; set; }
        [Required]
        public string Address { get; set; }
        public int CompanyId { get; set; }
        public MyCompany Company { get; set; }
     // public ICollection<Currency> Currencies { get; set; } = new List<Currency>();



    }
}
