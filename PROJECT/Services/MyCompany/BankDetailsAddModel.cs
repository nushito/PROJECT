using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PROJECT.Services.BankDetails
{
    using static PROJECT.Data.ConstantsValidation;
    public class BankDetailsAddModel
    {
        public int Id { get; init; }
        public int CurrencyId { get; set; }
        [Required]
        public string Currency { get; set; }
        [Required]
        public string BankName { get; set; }
        [MaxLength(IbanLength)]
        public string Iban { get; set; }
        [Required]
        public string Swift { get; set; }
        [Required]
        public string Address { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public ICollection<string> CompanyNames { get; set; }
        public IEnumerable<string> Currencies { get; set; }

    }
}
