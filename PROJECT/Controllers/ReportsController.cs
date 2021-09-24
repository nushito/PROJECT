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
        public IActionResult ReportProducts([FromQuery] ProductsAvailability model)
            //int supplierId,
            //string description,
            //string size, 
            //string grade, 
            //string customerName)
        {
            model.Descriptions = productService.GetDescription();            
            model.Sizes = productService.GetSize();
            model.Grades = productService.GetGrade();
            model.Suppliers = supplierService.GetSuppliers().Select(a=>a.Name);
            model.Customers = customerService.GetCustomers();           

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
                .Select(a => new ProductViewModel
                {
                    Description = a.Description,
                    Size = a.Size,
                    Grade = a.Grade,
                    Specification = new ProductSpecificationViewModel
                    {
                        BankExpenses = a.ProductSpecifications.Select(a => a.BankExpenses).FirstOrDefault(),
                        Cubic = a.ProductSpecifications.Select(a => a.Cubic).FirstOrDefault(),
                        CustomsExpenses = a.ProductSpecifications.Select(a=>a.CustomsExpenses).FirstOrDefault(),
                        Pieces = a.ProductSpecifications.Select(a=>a.Pieces).FirstOrDefault(),
                        Price = a.ProductSpecifications.Select(a=>a.Price).FirstOrDefault(),
                        CostPrice = a.ProductSpecifications.Select(a=>a.CostPrice).FirstOrDefault(),
                        Income = a.ProductSpecifications.Select(a=>a.Income).FirstOrDefault()
                    }
                })
                .ToList();

           model.Products = products;
            
           return View(model);

        }

    }
}
