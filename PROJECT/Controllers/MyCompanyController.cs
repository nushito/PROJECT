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
using System.Security.Claims;

namespace PROJECT.Controllers
{
    public class MyCompanyController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICurrency icurrency;
        private readonly IBankService bankService;
        private readonly IMycompanyService mycompany;
   
        public MyCompanyController (ApplicationDbContext dbContext
            ,ICurrency icurrency, IBankService bankService, IMycompanyService mycompany)
        {
            this.dbContext = dbContext;
            this.icurrency = icurrency;
            this.bankService = bankService;
            this.mycompany = mycompany;

        }
        public IActionResult Register()
        {
            return  View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Register(MyCompanyFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            string userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var company = new MyCompany
            {
                Id = model.Id,
                Name = model.Name,
                Eik = model.EIK,
                VAT = model.VAT,

                Address = new Address
                {
                    City = model.City,
                    Country = model.Country,
                    Street = model.Street
                },
                RepresentativePerson = model.RepresentativePerson,
                UserId = userId
           };
            
            dbContext.MyCompanies.Add(company);
            dbContext.SaveChanges();

            return RedirectToAction("Index","Home");
        }
        public IActionResult AddBank()       
        {
            return View(new AddBankDetailsFormModel
            { 
                CompanyNames = mycompany.GetCompany(),
                Currencies = icurrency.GetCurrencies()
            }); 
        }
              
        [Authorize]
        [HttpPost]
        public IActionResult AddBank(AddBankDetailsFormModel bankmodel)
        {
            if (!ModelState.IsValid)
            {
                bankmodel.Currencies = this.icurrency.GetCurrencies().ToList();
            }
                

                if (mycompany.GetCompany() == null)
            {
                return RedirectToAction("Register", "MyCompany");
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
       

    }
}
