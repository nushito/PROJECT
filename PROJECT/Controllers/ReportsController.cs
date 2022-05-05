using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJECT.Data;
using PROJECT.Models.Reports;
using PROJECT.Models.Reports.Customers;
using PROJECT.Services;
using PROJECT.Services.Customer;
using PROJECT.Services.Products;
using PROJECT.Services.Purchases;
using System.Linq;

namespace PROJECT.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IProductsService productService;
        private readonly ISupplierService supplierService;
        private readonly ICustomerService customerService;
        private readonly IPurchaseService purchaseService;
        public ReportsController(IProductsService productService, ISupplierService supplierService,
            ICustomerService customerService, ApplicationDbContext dbContext, IPurchaseService purchaseService)
        {
            this.dbContext = dbContext;
            this.productService = productService;
            this.supplierService = supplierService;
            this.customerService = customerService;
            this.purchaseService = purchaseService;
        }

        [Authorize]
        public IActionResult ReportProducts([FromQuery] ProductsAvailability model, string supplierName)
        //int supplierId,
        //string description,
        //string size, 
        //string grade, 

        {
            model.Descriptions = productService.GetDescription();            
            model.Sizes = productService.GetSize();
            model.Grades = productService.GetGrade();
            model.Suppliers = supplierService.GetSuppliers().Select(a=>a.Name);
            model.Customers = customerService.GetCustomers();
            model.PurchaseNumbers = purchaseService.AllPurchases();

            var listQuery = dbContext.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(model.Description))
            {
                listQuery = listQuery.Where(a => a.Description == model.Description);
            }
            if (!string.IsNullOrWhiteSpace(model.Size))
            {
                listQuery = listQuery.Where(a => a.Size == model.Size);
            }

            if (!string.IsNullOrWhiteSpace(model.Grade))
            {
                listQuery = listQuery.Where(a => a.Grade == model.Grade);
            }

            if (!string.IsNullOrWhiteSpace(model.SupplierName))
            {
                listQuery = listQuery.Where(a => a.Supplier.Name.ToLower() == supplierName.ToLower());
            }

            
           
            if (!string.IsNullOrWhiteSpace(model.CustomerName))
            {
                listQuery = listQuery.Where(a => a.Customers.Any(x => x.Name == model.CustomerName));
            }



            var products = listQuery
                .Select(a => new ProductViewModel
                {
                    Description = a.Description,
                    Size = a.Size,
                    Grade = a.Grade,
                    Quantity = a.Quantity,
                    Specification = new ProductSpecificationViewModel
                    {
                        BankExpenses = a.ProductSpecifications.Select(a => a.BankExpenses).FirstOrDefault(),
                        Cubic = a.ProductSpecifications.Select(a => a.Cubic).FirstOrDefault(),
                        CustomsExpenses = a.ProductSpecifications.Select(a=>a.CustomsExpenses).FirstOrDefault(),
                        Pieces = a.ProductSpecifications.Select(a=>a.Pieces).FirstOrDefault(),
                        Price = a.ProductSpecifications.Select(a=>a.Price).FirstOrDefault(),
                        CostPrice = a.ProductSpecifications.Select(a=>a.CostPrice).FirstOrDefault(),
                        Income = a.ProductSpecifications.Select(a=>a.Income).FirstOrDefault(),
                        PurchaseNumber = a.Purchases.Where(a=>a.Purchase.Supplier.Name == model.SupplierName).Select(a=>a.Purchase.InvoiceNumber).FirstOrDefault()
                    }
                })
                   .ToList();

           model.Products = products;
            
           return View(model);

        }


        public IActionResult ReportCustomer([FromQuery] CustomerByInvoice customersModel)
        {
            //var listInvoiceNums = customersModel.Invoices
            //    .Select(a => a.Number)
            //    .ToList();

            customersModel.CustomerNames = customerService.GetCustomers();
             customersModel.InvoiceNumbers = customerService.GetInvoices(customersModel.CustomerName);
            //var name = customersModel.CustomerName;
          
            var listCustomers = dbContext.Clients.AsQueryable();

            if (!string.IsNullOrWhiteSpace(customersModel.CustomerName))
            {
                listCustomers = listCustomers.Where(x => x.Name == customersModel.CustomerName);
            }

               
            var customers = listCustomers
                .Select(x => new DocumentsSelection
                {
                    Number = x.Invoices.Select(a=>a.Number).FirstOrDefault(),
                    Date = x.Invoices.Select(a=>a.Date).FirstOrDefault()                    

                }).ToList();

            customersModel.Invoices = customers;
           
            return View(customersModel);
        }
    }
}
