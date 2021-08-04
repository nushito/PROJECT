using PROJECT.Services.Curruncies;
using System.Collections.Generic;

namespace PROJECT.Services
{
    public interface ICurrency
    {

        public ICollection<string> GetCurrencies();
        //  public int GetCurrencyId(string a);
        public IEnumerable<GetCurrencyModel> AllCurrencies();
    }
}
