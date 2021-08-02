using PROJECT.Services.Curruncies;
using System.Collections.Generic;

namespace PROJECT.Services
{
    public interface ICurrency
    {

        public IEnumerable<string> GetCurrencies();
        //  public int GetCurrencyId(string a);
        public IEnumerable<GetCurrencyModel> AllCurrencies();
    }
}
