using InvoiceAndStockModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using PROJECT.Data;
using PROJECT.Models.Purchases;
using PROJECT.Data.Models;

namespace PROJECT.Controllers
{
    public class PurchasesController:Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ISupplierService supplierService;
        public PurchasesController(ApplicationDbContext dbContext, ISupplierService supplierService)
        {
            this.dbContext = dbContext;
            this.supplierService = supplierService;
        }
        public IActionResult AddPurchase()
        {
          
            return View(new PurchaseFormModel
            {
                Suppliers = supplierService.GetSuppliers()
            });
             
        }

        [HttpPost]
        public IActionResult AddPurchase(PurchaseFormModel model, 
            PurchaseProductFormModel purchasemodel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home");
            }

            if (!model.Suppliers.Any())
            {
                return RedirectToAction(nameof(SuppliersController.AddSupplier),"Suppliers");
            }

            var supplier = this.dbContext
                .Suppliers
                .Where(a => a.Name.ToLower() == model.SupplierName.ToLower())
                .FirstOrDefault();
            
            var purchase = new Purchase
            {
                Supplier = supplier,
                Date = DateTime.Parse(model.Date),
                InvoiceNumber = model.InvoiceNumber,
             };

           // var product = AddProduct(purchasemodel);
            //var product = this.dbContext
            //    .Products
            //    .Where(a => a.Id == purchasemodel.Id)
            //    .FirstOrDefault();

            //if(product == null)
            //{

            //var newProduct = AddProduct();
            //    purchase.Products.Add(newProduct);
          //  supplier.Products.Add(product);
            
            this.dbContext.Purchases.Add(purchase);

            return View(purchase);
        }

        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(PurchaseProductFormModel purchasemodel)
        {
            var newProduct = new Product
            {
                Id = purchasemodel.Id,
                Description = purchasemodel.ProductDescription,
                Size = purchasemodel.Size,
                Grade = purchasemodel.Grade,
                Price = purchasemodel.PurchasePrice,
                Quantity = purchasemodel.Quantity,
                Unit = purchasemodel.Unit,
                TransportCost = purchasemodel.TransportCost,
                CustomsExpenses = purchasemodel.CustomsExpenses,
                BankExpenses = purchasemodel.BankExpenses,
                Duty = purchasemodel.Duty,
                TerminalCharges = purchasemodel.TerminalCharges,
            };
            
           this.dbContext.Products.Add(newProduct);
            this.dbContext.SaveChanges();

            return View("AddPurchase", newProduct);
        }
        [HttpPost]
        public IActionResult Add(Product product)
        {
           
            return View("AddPurchase", product);
        }
        
      
    }
    
    }

