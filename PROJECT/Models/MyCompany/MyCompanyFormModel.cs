
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
        public string CompanyEik { get; set; }
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
