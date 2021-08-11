using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using PROJECT.Data;
using PROJECT.Models.Purchases;
using PROJECT.Data.Models;
using PROJECT.Services.Supplier;
using PROJECT.Services.Products;
using System.Threading.Tasks;
using PROJECT.Services.Purchases;
using PROJECT.Services;
using System.Collections;

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
                Descriptions = productsService.GetDescription(),
                    Sizes = productsService.GetSize(),
                    Grades = productsService.GetGrade()
               
            }) ;             
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddPurchase(
            PurchaseFormModel model 
           )
        {
            if (!ModelState.IsValid)
            {
                return View();
                //model.Suppliers = supplierService.GetSuppliers();
                //model.PurchaseProducts = new PurchaseProductFormModel
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

            if (!model.Suppliers.Any())
            {
              
                return RedirectToAction(nameof(SuppliersController.AddSupplier),"Suppliers");
            }

            var purchaseId =  purchaseService.Create(model.SupplierId, model.Date, model.InvoiceNumber
            ,model.PurchaseProductFormModel.ProductDescription,
            model.PurchaseProductFormModel.Size,
            model.PurchaseProductFormModel.Grade,
            model.PurchaseProductFormModel.Pieces,
            model.PurchaseProductFormModel.Cubic,
            model.PurchaseProductFormModel.PurchasePrice,
            model.PurchaseProductFormModel.TerminalCharges,
            model.PurchaseProductFormModel.Duty,
            model.PurchaseProductFormModel.CustomsExpenses,
            model.PurchaseProductFormModel.BankExpenses);

            return RedirectToAction("Index","Home");
        }       
      

        public IActionResult AddProductToPurchase(PurchaseProductFormModel model)
        {
            var idPr = purchaseService.SaveProduct(
                model.Id,
                model.ProductDescription,
                model.Size,
                model.Grade,
                model.Pieces,
                model.Cubic,               
                model.PurchasePrice,
                model.TransportCost,
                model.TerminalCharges,
                model.Duty,
                model.CustomsExpenses,
                model.BankExpenses);

            IList list = null;

            for (int i = 0; i <= Request.Form.Count; i++)
            {
                var productDescription = Request.Form["ProductDescription[" + i + "]"];
                var size = Request.Form["Size[" + i + "]"];
                var grade = Request.Form["Grade[" + i + "]"];
                var pices = Request.Form["Pieces[" + i + "]"];
                var cubic = Request.Form["Cubic[" + i + "]"];
                var purchasePrice = Request.Form["PurchasePrice[" + i + "]"];
                var transportCost = Request.Form["TransportCost[" + i + "]"];
                var terminalCharges = Request.Form["TerminalCharges[" + i + "]"];
                var duty = Request.Form["Duty[" + i + "]"];
                var customsExpenses = Request.Form["CustomsExpenses[" + i + "]"];
                var bankExpenses = Request.Form["BankExpenses[" + i + "]"];

                if ((productDescription.ToString() != null) && (size.ToString() != null)
                    && (grade.ToString() != null) && (pices != 0)&& (cubic != 0) &&
                    (purchasePrice != 0) && (transportCost != 0) && (terminalCharges != 0) && (duty != 0) && 
                    (customsExpenses != 0) && (bankExpenses != 0))
                {
                    var product = this.dbContext.Products
                        .Where(a => a.Description.ToLower() == model.ProductDescription.ToLower()
                    && a.Size.ToLower() == model.Size.ToLower()
                    && a.Grade.ToLower() == model.Grade.ToLower())
                        .FirstOrDefault();
                    var productDetails = new ProductSpecification
                    {
                        BankExpenses = Decimal.Parse(bankExpenses),
                        Cubic = Decimal.Parse(cubic),
                        CustomsExpenses = Decimal.Parse(customsExpenses),
                        Duty = Decimal.Parse(duty),
                        Pieces = int.Parse(pices),
                        Price = Decimal.Parse(purchasePrice),
                        TerminalCharges = Decimal.Parse(terminalCharges),
                        TransportCost = Decimal.Parse(transportCost)
                    };

                    product.ProductSpecifications.Add(productDetails);

                    list.Add(product) ;


                    //  _Client.Add(new Client { ClientName = ClientName, Email = EMail });
                      
                }
            }
            return RedirectToAction(nameof(AddPurchase));
        }

    }
    
 }

