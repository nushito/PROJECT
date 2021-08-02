using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace PROJECT.Models.MyCompany
{
    public class AddBankDetailsFormModel
    {
        public AddBankDetailsFormModel()
        {
            Currencies = new List<string>();
            CompanyNames = new List<string>();
        }
        public int Id { get; init; }
        [Required]
        public IEnumerable<string> Currencies { get; init; }

        public string Currency { get; set; }
        [Required]
        public string BankName { get; set; }
       
        public string Iban { get; set; }
        [Required]
        public string Swift { get; set; }
        [Required]
        public string Address { get; set; }
      
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public ICollection<string> CompanyNames { get; set; }
       
      //  public ICollection<MyCompanyGetNameModel> Company { get; set; } = new List<MyCompanyGetNameModel>();
    }
}
