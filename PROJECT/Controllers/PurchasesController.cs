using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using PROJECT.Data;
using PROJECT.Models.Purchases;
using PROJECT.Data.Models;
using PROJECT.Services.Products;
using PROJECT.Services.Purchases;
using PROJECT.Services;
using System.Collections.Generic;

namespace PROJECT.Controllers
{
    public class PurchasesController:Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly ISupplierService supplierService;
        private readonly IProductsService productsService;
        private readonly IPurchaseService purchaseService;
       
        public PurchasesController(ApplicationDbContext dbContext, 
            ISupplierService supplierService,
            IProductsService productsService,
            IPurchaseService purchaseService)
        {
            this.dbContext = dbContext;
            this.supplierService = supplierService;
            this.productsService = productsService;
            this.purchaseService = purchaseService;
           
        }
        [Authorize]
        public IActionResult AddPurchase()
        {

            return View(new PurchaseFormModel
            {
                
                Suppliers = supplierService.GetSuppliers(),
                //PurchaseProductViewModel = new PurchaseProductViewModel
                //{
                //    Descriptions = productsService.GetDescription(),
                //    Sizes = productsService.GetSize(),
                //    Grades = productsService.GetGrade()
                //}
            }) ;
                      
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddPurchase(PurchaseFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Suppliers = supplierService.GetSuppliers();
                //model.PurchaseProductViewModel = new PurchaseProductViewModel
                //{
                //    Descriptions = productsService.GetDescription(),
                //    Sizes = productsService.GetSize(),
                //    Grades = productsService.GetGrade()
                //};
            }

            if (!this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }

            var purchaseId =  purchaseService.Create(model.SupplierId, model.Date, model.Number);

            // ICollection<Product> list = new List<Product>();

            
          
            return RedirectToAction("AddPurchaseProducts", new { PurchaseId = purchaseId });
        }

        [Authorize]
        public IActionResult AddPurchaseProducts()
        {
            return View(
                  new List<PurchaseProductViewModel>
                {new PurchaseProductViewModel
            {
                    Descriptions = productsService.GetDescription(),
                    Sizes = productsService.GetSize(),
                    Grades = productsService.GetGrade(),
                ProductSpecificationFormModels = new List<ProductSpecificationFormModel>()

            }});
         }

        [HttpPost]
        [Authorize]
        public IActionResult AddPurchaseProducts(int purchaseId, PurchaseProductViewModel productViewModel,
            ICollection<PurchaseProductViewModel> model)
        {


            if (!ModelState.IsValid)
            {
                new List<PurchaseProductViewModel>
                {new PurchaseProductViewModel
            {
                    Descriptions = productsService.GetDescription(),
                    Sizes = productsService.GetSize(),
                    Grades = productsService.GetGrade(),
                ProductSpecificationFormModels = new List<ProductSpecificationFormModel>()

            }};
            }



            //   model = new List<PurchaseProductViewModel>();

            var thisPurchase = dbContext.Purchases.Find(purchaseId);
            var listProducts = new HashSet<ProductPurchase>();


            foreach (var item in model)
            {
                
            }
           
           
            for (int i = 0; i < model.Count; i++)
            {

               
                var productDescription = Request.Form["Description[" + i + "]"];
                var size = Request.Form["Size[" + i + "]"];
                var grade = Request.Form["Grade[" + i + "]"];
                var pieces = Request.Form["Pieces[" + i + "]"];
                var cubic = Request.Form["Cubic[" + i + "]"];
                var purchasePrice = Request.Form["Price[" + i + "]"];
                var transportCost = Request.Form["TransportCost[" + i + "]"];
                var terminalCharges = Request.Form["TerminalCharges[" + i + "]"];
                var duty = Request.Form["Duty[" + i + "]"];
                var customsExpenses = Request.Form["CustomsExpenses[" + i + "]"];
                var bankExpenses = Request.Form["BankExpenses[" + i + "]"];

                if ((productDescription.ToString() != null) && (size.ToString() != null)
                    && (grade.ToString() != null) && (pieces != 0) && (cubic != 0) &&
                    (purchasePrice != 0) && (transportCost != 0) && (terminalCharges != 0) && (duty != 0) &&
                    (customsExpenses != 0) && (bankExpenses != 0))
                {
                    var product = this.dbContext.Products
                        .Where(a => a.Description.ToLower() == productDescription.ToString().ToLower()
                    && a.Size.ToLower() == size.ToString().ToLower()
                    && a.Grade.ToLower() == grade.ToString().ToLower()
                   )
                        .FirstOrDefault();

                    var productDetails = new ProductSpecification
                    {

                        BankExpenses = Math.Round(decimal.Parse(bankExpenses.ToString()), 4),
                        Cubic = Math.Round(decimal.Parse(cubic.ToString()), 4),
                        CustomsExpenses = Math.Round(decimal.Parse(customsExpenses.ToString()), 4),
                        Duty = Math.Round(decimal.Parse(duty.ToString()), 4),
                        Pieces = int.Parse(pieces.ToString()),
                        Price = Math.Round(decimal.Parse(purchasePrice.ToString()), 4),
                        TerminalCharges = Math.Round(decimal.Parse(terminalCharges.ToString()), 4),
                        TransportCost = Math.Round(decimal.Parse(transportCost.ToString()), 4),

                    };

                    var costPrice = (
                       decimal.Parse(bankExpenses.ToString()) +
                       decimal.Parse(customsExpenses.ToString()) +
                       decimal.Parse(duty.ToString()) +
                       decimal.Parse(terminalCharges.ToString()) +
                       decimal.Parse(transportCost.ToString()) +
                       decimal.Parse(cubic.ToString()) * decimal.Parse(purchasePrice.ToString())
                       ) / decimal.Parse(cubic.ToString());

                    productDetails.CostPrice = costPrice;

                    //  var thisSupplier = dbContext.Suppliers.Find(model.SupplierId);
                    //if (product.Supplier.Name != (model.SupplierName))
                    //{

                    //    product.Supplier = (thisSupplier);//new Supplier { Id = model.SupplierId, Name = model.SupplierName });
                    //}

                    product.ProductSpecifications.Add(productDetails);
                    var x = new ProductPurchase
                    {
                        ProductId = product.Id,
                        PurchaseId = purchaseId
                   
                    };
                   
                  listProducts.Add(x);
                    dbContext.SaveChanges();
                }
            }

          
           
            thisPurchase.Products = listProducts;
            dbContext.SaveChanges();

            return View();
        }
           
       

    }
    
 }

