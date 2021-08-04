using PROJECT.Data;
using PROJECT.Services.Curruncies;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PROJECT.Services
{
    public class Currency : ICurrency
    {
        private readonly ApplicationDbContext dbContext;

        public Currency(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<GetCurrencyModel> AllCurrencies()
        {
            return this.dbContext
                 .Currencies
                 .Select(a => new GetCurrencyModel
                 {
                     Name = a.Name,
                     Id = a.Id
                 })
                 .ToList();
        }

        ICollection<string> ICurrency.GetCurrencies()
        {
            return this.dbContext
                .Currencies
                .Select(a => a.Name)
                .ToList();

        }



        //public int GetCurrencyId(string currencyName)
        //{
        //    var id = this.dbContext
        //        .BankDetails
        //        .Where(x => x.Currency.ToLower() == currencyName.ToLower())
        //        .Select(a=>a.CurrencyId)
        //        .FirstOrDefault();

        //    return id;
        //}
    }
}
