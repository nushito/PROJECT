using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJECT.Data;
using PROJECT.Data.Models;
using PROJECT.Models.MyCompany;
using PROJECT.Services;
using PROJECT.Services.BankDetails;
using PROJECT.Services.MyCompany;

namespace PROJECT.Controllers
{
    public class MyCompanyController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICurrency icurrency;
        private readonly IBankService bankService;
   
        public MyCompanyController (ApplicationDbContext dbContext
            ,ICurrency icurrency)
        {
            this.dbContext = dbContext;
            this.icurrency = icurrency;

        }
        public IActionResult Register()
        {
            return  View();
        }
        [HttpPost]
        public IActionResult Register(MyCompanyFormModel model)
        {
           
            string userId = User.Identity.GetUserId();

           var company = new MyCompany
            {
                Id = model.Id,
                Name = model.Name,
                Eik = model.CompanyEik,
                VAT = model.CompanyVat,

                Address = new Address
                {
                    City = model.City,
                    Country = model.Country,
                    Street = model.Address
                },
                RepresentativePerson = model.RepresentativePerson,
               UserId = userId
           };
            
            dbContext.MyCompanies.Add(company);
            dbContext.SaveChanges();

            return RedirectToAction(nameof(AddBank));
        }
        public IActionResult AddBank()       
        {
            return View(new AddBankDetailsFormModel
            {
                CompanyNames = this.GetCompany(),
                Currencies = icurrency.GetCurrencies()
            }) ;
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddBank(BankDetailsAddModel bankmodel)
        {
            if (!ModelState.IsValid)
            {
               bankmodel.Currencies = this.icurrency.GetCurrencies();
            }

            bankService.Create(
                bankmodel.CurrencyId,
                bankmodel.BankName,
                bankmodel.Iban,
                bankmodel.Swift,
                bankmodel.Address,
                bankmodel.CompanyName,
                bankmodel.CompanyId
                );
          //  string currency, string bankName, string iban, string swift, string address, string companyName, int companyId
            //var bankdetails = new BankDetails
            //{
            //    Currency = bankmodel.Currency,
            //    Address = bankmodel.Address,
            //    Iban = bankmodel.Iban,
            //    Swift = bankmodel.Swift,
            //    BankName = bankmodel.BankName, 
            //    CompanyName = bankmodel.CompanyName,
            //  };

            //dbContext.BankDetails.Add(bankdetails);
           

            return RedirectToAction("Index","Home");
        }

        public ICollection<string> GetCompany()
        {
            return dbContext.MyCompanies
                .Select(x=> x.Name)
                .ToList();
        }

        

    }
}
