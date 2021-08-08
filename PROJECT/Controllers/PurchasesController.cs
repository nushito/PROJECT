using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using PROJECT.Data;
using PROJECT.Models.Purchases;
using PROJECT.Data.Models;
using PROJECT.Services;
using PROJECT.Services.Products;
using System.Threading.Tasks;

namespace PROJECT.Controllers
{
    public class PurchasesController:Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ISupplierService supplierService;
        private readonly IProductsService productsService;
        public PurchasesController(ApplicationDbContext dbContext, 
            ISupplierService supplierService,
            IProductsService productsService)
        {
            this.dbContext = dbContext;
            this.supplierService = supplierService;
            this.productsService = productsService;
        }
        [Authorize]
        public IActionResult AddPurchase()
        {

            return View(new PurchaseFormModel
            {
                Suppliers = supplierService.GetSuppliers(),
                Descriptions = productsService.GetDescription(),
                Sizes = productsService.GetSize(),
                Grades = productsService.GetGrade()
            }) ;             
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddPurchase(
            PurchaseFormModel model, 
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

            var supplier =  this.dbContext
                .Suppliers
                .Where(a => a.Name.ToLower() == model.SupplierName.ToLower())
                .FirstOrDefault();
            
            var purchase = new Purchase
            {
                Supplier = supplier,
                Date = DateTime.Parse(model.Date),
                InvoiceNumber = model.InvoiceNumber,
            };


            var product = this.dbContext
                .Products
                .Where(a => a.Id == purchasemodel.Id)
                .FirstOrDefault();

            this.dbContext.Purchases.Add(purchase);
           // product.Suppliers.Add(new Supplier{id = purchase.Supplier.Id);

          dbContext.SaveChanges();
            return View(purchase);
        }

        
        [HttpPost]
        public IActionResult Add(Product product)
        {
           
            return View("AddPurchase", product);
        }
        
      
    }
    
    }

