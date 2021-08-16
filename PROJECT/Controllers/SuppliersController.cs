
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJECT.Data;
using PROJECT.Data.Models;
using PROJECT.Models.Suppliers;
using PROJECT.Services;

namespace PROJECT.Controllers
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
            if (!ModelState.IsValid)
            {
                return View();
            }
            var supplier = new Supplier
            { 
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
                RepresentativePerson = model.RepresentativePerson
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
  
