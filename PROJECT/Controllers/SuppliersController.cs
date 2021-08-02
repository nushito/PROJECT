using InvoiceAndStockModels;
using InvoiceAndStockModels.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SIAS.Data;
using SIAS.Models.Suppliers;
using SIAS.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIAS.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ICurrency currencyGet;
        public SuppliersController(ApplicationDbContext dbContext, 
            ICurrency currencyGet)
        {
            this.dbContext = dbContext;
            this.currencyGet = currencyGet;
        }

        [Authorize]
             public IActionResult AddSupplier()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddSupplier(
          AddSupplierModel model
            )
        {

            var supplier = new Supplier
            { 
                Id = model.Id,
                Name = model.Name,
                VAT = model.VAT,
                Eik = model.Eik,
                Email = model.Email,
                SupplierAddress = new Address
                {
                    City = model.City,
                    Street = model.SupplierAddress,
                    Country = model.Country
                },
            };

            //var currencyList = model.Currencies
            //    .Select(a => (AccountCurrency) Enum.Parse(typeof(AccountCurrency), a)).ToList();

            //var bankDetail = new BankDetails
            //{
            //    BankName = model.BankName,
            //    Iban = model.Iban,
            //    Address = model.BankAddress,
            //    Swift = model.Swift,
            //    Currency = new InvoiceAndStockModels.Currency { AccountCurrency = (AccountCurrency)Enum.Parse(typeof(AccountCurrency), model.Currency) }  //(AccountCurrency)Enum.Parse(typeof(AccountCurrency),model.Currency)              
            //};

            //supplier.BankDetails.Add(bankDetail);

            this.dbContext.Suppliers.Add(supplier);
            this.dbContext.SaveChanges();

            return View();
                //RedirectToAction("AddPurchase");

        }
    }
        }
  
