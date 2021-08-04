using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Models.MyCompany
{
    public class AddBankViewModel
    {
        public AddBankViewModel()
        {
            Currencies = new List<string>();
            CompanyNames = new List<string>();
        }
        public AddBankDetailsFormModel AddBankModel { get; set; }
        public ICollection<string> CompanyNames { get; set; }
         public ICollection<string> Currencies { get; set; }
    }
}
