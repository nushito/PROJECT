﻿
namespace PROJECT.Services.MyCompany
{
    using PROJECT.Data;
    using PROJECT.Data.Models;
    using System.Linq;
  
    public class BankService : IBankService
    {
        private readonly ApplicationDbContext dbContext;
        public BankService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int Create(int currencyId, string bankName, string iban, string swift, string address, string companyName, int companyId)
        {

            var newBank = new BankDetails
            {
                 CurrencyId = currencyId,
                 BankName = bankName,
                 Iban = iban,
                 Swift = swift,
                 Address = address,
                 Company = new MyCompany
                 {
                     Name = companyName,
                     Id = companyId
                 }
        };

             var company = dbContext.MyCompanies
                .Where(a => a.Name.ToLower() == companyName.ToLower())
                .FirstOrDefault();

            company.BankDetails.Add(newBank);

            dbContext.SaveChanges();
            return newBank.Id;
           
        }
    }
}
