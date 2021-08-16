﻿using Microsoft.AspNetCore.Mvc;
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
                PurchaseProductFormModel = new PurchaseProductFormModel
                {
                    Descriptions = productsService.GetDescription(),
                    Sizes = productsService.GetSize(),
                    Grades = productsService.GetGrade()
                }
            });
               
                     
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddPurchase(PurchaseFormModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Suppliers = supplierService.GetSuppliers();
                model.PurchaseProductFormModel = new PurchaseProductFormModel
                {
                    Descriptions = productsService.GetDescription(),
                    Sizes = productsService.GetSize(),
                    Grades = productsService.GetGrade()
                };
            }

            if (!this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }

            var purchaseId =  purchaseService.Create(model.SupplierId, model.Date, model.InvoiceNumber           
            );

            //var idPr = purchaseService.SaveProduct(
            //    model.PurchaseProductFormModel.Description,
            //    model.PurchaseProductFormModel.Size,
            //    model.PurchaseProductFormModel.Grade,
            //    model.PurchaseProductFormModel.Pieces,
            //    model.PurchaseProductFormModel.Cubic,
            //    model.PurchaseProductFormModel.PurchasePrice,
            //    model.PurchaseProductFormModel.TransportCost,
            //    model.PurchaseProductFormModel.TerminalCharges,
            //    model.PurchaseProductFormModel.Duty,
            //    model.PurchaseProductFormModel.CustomsExpenses,
            //    model.PurchaseProductFormModel.BankExpenses);


            ICollection<Product> list = null;

            for (int i = 0; i <= Request.Form.Count; i++)
            {
                var productDescription = Request.Form["Description[" + i + "]"];
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
                    && (grade.ToString() != null) && (pices != 0) && (cubic != 0) &&
                    (purchasePrice != 0) && (transportCost != 0) && (terminalCharges != 0) && (duty != 0) &&
                    (customsExpenses != 0) && (bankExpenses != 0))
                {
                    var product = this.dbContext.Products
                        .Where(a => a.Description.ToLower() == productDescription.ToString().ToLower()
                    && a.Size.ToLower() == size.ToString().ToLower()
                    && a.Grade.ToLower() == grade.ToString().ToLower())
                        .FirstOrDefault();

                    var costPrice = (Decimal.Parse(bankExpenses) + Decimal.Parse(customsExpenses) + Decimal.Parse(duty)
                        + Decimal.Parse(terminalCharges) + Decimal.Parse(transportCost) + Decimal.Parse(cubic) * Decimal.Parse(purchasePrice)
                        ) / Decimal.Parse(cubic);

                    var productDetails = new ProductSpecification
                    {
                        BankExpenses = Decimal.Parse(bankExpenses),
                        Cubic = Decimal.Parse(cubic),
                        CustomsExpenses = Decimal.Parse(customsExpenses),
                        Duty = Decimal.Parse(duty),
                        Pieces = int.Parse(pices),
                        Price = Decimal.Parse(purchasePrice),
                        TerminalCharges = Decimal.Parse(terminalCharges),
                        TransportCost = Decimal.Parse(transportCost),
                        CostPrice = costPrice
                    };

                  
                    product.ProductSpecifications.Add(productDetails);

                    list.Add(product);

                }
            }

            var one = dbContext.Purchases.Find(purchaseId);
            one.Products = list;
           // one.Products = AddProductToPurchase(model.PurchaseProductFormModel);
            return RedirectToAction("Index","Home");
        }    
        
        
        [HttpPost]
        public ICollection<Product> AddProductToPurchase(PurchaseProductFormModel model)
        {
            model.Descriptions = productsService.GetDescription();
            model.Sizes = productsService.GetSize();
            model.Grades = productsService.GetGrade();

            var idPr = purchaseService.SaveProduct(
                model.Description,
                model.Size,
                model.Grade,
                model.Pieces,
                model.Cubic,               
                model.Price,
                model.TransportCost,
                model.TerminalCharges,
                model.Duty,
                model.CustomsExpenses,
                model.BankExpenses);

            ICollection<Product> list = null;

            for (int i = 0; i <= Request.Form.Count; i++)
            {
                var productDescription = Request.Form["Description[" + i + "]"];
                var size = Request.Form["Size[" + i + "]"];
                var grade = Request.Form["Grade[" + i + "]"];
                var pices = Request.Form["Pieces[" + i + "]"];
                var cubic = Request.Form["Cubic[" + i + "]"];
                var purchasePrice = Request.Form["Price[" + i + "]"];
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
                        .Where(a => a.Description.ToLower() == model.Description.ToLower()
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

                }
            }
            return list;
        }

    }
    
 }

