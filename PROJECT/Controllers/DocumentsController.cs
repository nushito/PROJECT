using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJECT.Data;
using PROJECT.Data.Models;
using PROJECT.Models.Documents;
using PROJECT.Models.Products;
using PROJECT.Services.Documents;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace PROJECT.Controllers
{
    public class DocumentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IDocumentService documentService;

        public DocumentsController(ApplicationDbContext dbContext,
            IDocumentService documentService)
        {
            this.dbContext = dbContext;
            this.documentService = documentService;
        }


        [Authorize]
        public IActionResult CreateInvoice()
        {
            var document = new InvoiceModel
            {
                Number = documentService.GetLastNumInvoice(),
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
        public IActionResult CreateInvoice(InvoiceModel model)
        {
            if (!ModelState.IsValid)
            {
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

            IList<Product> listInvoice = new List<Product>();

            for (int i = 0; i < Request.Form.Count; i++)
            {
                var productDescription = Request.Form["Description[" + i + "]"];
                var size = Request.Form["Size[" + i + "]"];
                var grade = Request.Form["Grade[" + i + "]"];
                var price = Request.Form["SoldPrice[" + i + "]"];
                var cubic = Request.Form["Cubic[" + i + "]"];
                var amount = Request.Form["Amount[" + i + "]"];

                
                var product = dbContext.Products.
                    Where(a => a.Description == productDescription && a.Size == size && a.Grade == grade)
                    .FirstOrDefault();

                var spec = new ProductSpecification
                {
                     SoldPrice = decimal.Parse(price.ToString()),
                     Cubic = decimal.Parse(cubic.ToString())
                };

                product.ProductSpecifications.Add(spec);
              

                listInvoice.Add(product);
                dbContext.SaveChanges();
            }

            var customer = dbContext.Clients.Where(a => a.Name.ToLower() == model.Client.Name.ToLower())
                .FirstOrDefault();

            var issuedDocument = new Invoice
            {
                Id = model.Id,
                Seller = seller,
                Client = customer,
                Date = model.Date,
                Number = model.Number,         
                SubTotal = model.SubTotal,
                Total = model.Total,
                VatParcent = model.VatPercent,
                Products = listInvoice
            };

            dbContext.Invoices.Add(issuedDocument);
            dbContext.SaveChanges();


           
            return RedirectToAction("Index","Home");
        }

    }
}
