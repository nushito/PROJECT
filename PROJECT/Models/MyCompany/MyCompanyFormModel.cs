
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Models.MyCompany
{
    public class MyCompanyFormModel
    {
        public MyCompanyFormModel()
        {
            BankDetails = new List<AddBankDetailsFormModel>();
        }
        public int Id { get; init; } 
        [Required]
        public string Name { get; set; }

        [Required]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "EIK number should be 9 symbols long.")]
        public string CompanyEik { get; set; }
        [Required]
        [StringLength(11, MinimumLength = 9, ErrorMessage = "VAT number should be 11 symbols long.")]
        public string VAT { get; set; }
    
        [Required]
        public string CompanyVat { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string RepresentativePerson { get; set; }
        public ICollection<AddBankDetailsFormModel> BankDetails { get; set; }

        // public ICollection<AddBankDetailsFormModel> BankDetails { get; set; }

    }
}
