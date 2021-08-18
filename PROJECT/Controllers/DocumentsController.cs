using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJECT.Data;
using PROJECT.Data.Models;
using PROJECT.Models.Documents;
using PROJECT.Models.Products;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PROJECT.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public DocumentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [Authorize]
        public IActionResult Create()
        {
            
            ViewBag.Number = 000000000;
            var document = new DocumentFormModel
            {
                Number = ViewBag.Number,
                Types = new List<string>()
                {
                    "Invoice", "Proforma Invoice", "CreditNote", "Order" },
                Seller = dbContext.MyCompanies.
                Where(a => a.UserId == this.User.FindFirstValue(ClaimTypes.NameIdentifier)).
                Select(a => new SupplierModel
                {
                     City = a.Address.City,
                     Country = a.Address.Country,
                     Street = a.Address.Street,
                     EIK = a.Eik,
                     VAT = a.VAT,
                     Name = a.Name
                }).FirstOrDefault(),
                Customers = dbContext.Clients.Select(a => a.Name).ToList()               
            };
            return View(document);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(DocumentFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Types = new List<string>()
                {
                    "Invoice", "Proforma Invoice", "CreditNote", "Order" };
                model.Seller = dbContext.MyCompanies.
                             Where(a => a.UserId == this.User.FindFirstValue(ClaimTypes.NameIdentifier)).
                        Select(a => new SupplierModel
                        {
                            City = a.Address.City,
                            Country = a.Address.Country,
                            Street = a.Address.Street,
                            EIK = a.Eik,
                            VAT = a.VAT,
                            Name = a.Name
                        }).FirstOrDefault();

                 model.Customers = dbContext.Clients.Select(a => a.Name).ToList();                 
            }

            model.Seller = dbContext.MyCompanies.
                            Where(a => a.UserId == this.User.FindFirstValue(ClaimTypes.NameIdentifier)).
                       Select(a => new SupplierModel
                       {
                           City = a.Address.City,
                           Country = a.Address.Country,
                           Street = a.Address.Street,
                           EIK = a.Eik,
                           VAT = a.VAT,
                           Name = a.Name
                       }).FirstOrDefault();

            var seller = dbContext.MyCompanies.
                Where(a => a.UserId == this.User.FindFirstValue(ClaimTypes.NameIdentifier))
                .FirstOrDefault();


            if (model.Seller == null)
            {
                RedirectToAction("Register", "MyCompany");
            }

          if(model.Type.ToString() == "Invoice")
            {
                model.Document = new InvoiceModel {Seller = model.Seller };
            }
          else if (model.Type.ToString() == "Proforma Invoice")
            {
                model.Document = new ProformaModel { Seller = model.Seller };
            }
            else if(model.Type.ToString() == "Order")
            {
                model.Document = new OrderModel { Seller = model.Seller };
            }
            else
            {
                model.Document = new CreditNote { Seller = model.Seller };
            };

            
            for (int i = 0; i < Request.Form.Count; i++)
            {
                var products = new AddProductsFormModel
                {

                };

            }
            
            
            var issuedDocument = new Document
            {
                Type = model.Type,
                Seller = seller,
                ClientId = model.Document.ClientId,
                Date = model.Document.Date,
                Number = model.Document.Number,         
                SubTotal = model.SubTotal,
                Total = model.Total,
                VatParcent = model.VatParcent
            };
           
            
            return View();
        }

    }
}
