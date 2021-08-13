using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJECT.Data;
using PROJECT.Models.Reports;
using PROJECT.Services;
using PROJECT.Services.Customer;
using PROJECT.Services.Products;
using System.Linq;

namespace PROJECT.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IProductsService productService;
        private readonly ISupplierService supplierService;
        private readonly ICustomerService customerService;
        public ReportsController(IProductsService productService, ISupplierService supplierService,
            ICustomerService customerService, ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.productService = productService;
            this.supplierService = supplierService;
            this.customerService = customerService;
        }

        [Authorize]
        public IActionResult ReportProducts()
        {
            return View(new ProductsAvailability
            {
                Descriptions = productService.GetDescription()
                .Select(a => a.Name).ToList(),
                Sizes = productService.GetSize()
                .Select(a => a.Name).ToList(),
                Grades = productService.GetDescription()
                .Select(a => a.Name).ToList(),
                Suppliers = supplierService.GetSuppliers().
                Select(a => a.Name).ToList(),
                Customers = customerService.GetCustomers()
            });
            

        }

        [Authorize]
        public IActionResult ReportProducts(ProductsAvailability model)
        {
            var descriptions = productService.GetDescription()
                .Select(a => a.Name).ToList();
            var sizes = productService.GetSize()
               .Select(a => a.Name).ToList();
            var grades = productService.GetDescription()
                .Select(a => a.Name).ToList();
            var suppliers = supplierService.GetSuppliers().
                Select(a => a.Name).ToList();
            var customers = customerService.GetCustomers();
           

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
                listQuery = listQuery.Where(a => a.Suppliers.Any(x => x.Name == model.SupplierName));
            }

            if (!string.IsNullOrWhiteSpace(model.CustomerName))
            {
                listQuery = listQuery.Where(a => a.Customers.Any(x => x.Name == model.CustomerName));
            }

            var products = listQuery
                .Select(a=>new ProductViewModel { 
                 ProductDescription = a.Description,
                 Size = a.Size,
                 Grade = a.Grade,
                  Cubic = a.ProductSpecifications.Select(a=>a.Cubic).FirstOrDefault(),
                   CostPrice = a.ProductSpecifications.Select(a=>a.Price).FirstOrDefault(),
                    Income = a.ProductSpecifications.Select(a=>a.Price).FirstOrDefault(),
                 
                }).ToList();
            //var pro = listQuery.Select(a => new 
            //{
            //    de = descriptions,
            //    Sizes = sizes,
            //    Grades = grades

            //}).ToList();
            //var listOfProducts = new ProductsAvailability
            //{

            //    Products = listQuery
            //};

            //model.Products = listQuery.ToList();

            var pro = new ProductsAvailability
            {
                Descriptions = descriptions,
                Sizes = sizes,
                Grades = grades,
                Suppliers = suppliers,
                Customers = customers,
                
            };

            return View(pro);

        }

    }
}
