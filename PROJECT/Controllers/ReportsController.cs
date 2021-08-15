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
        public IActionResult ReportProducts(ProductsAvailability model,
            int supplierId,
            string description,
            string size, 
            string grade, 
            string customerName)
        {
            var descriptions = productService.GetDescription();            
            var sizes = productService.GetSize();
            var grades = productService.GetDescription();
            var suppliers = supplierService.GetSuppliers().Select(a=>a.Name);
            var customers = customerService.GetCustomers();           

            var listQuery = dbContext.Products.AsQueryable();

            if (!string.IsNullOrWhiteSpace(description))
            {
                listQuery = listQuery.Where(a => a.Description == description);
            }
            if (!string.IsNullOrWhiteSpace(size))
            {
                listQuery = listQuery.Where(a => a.Size == size);
            }

            if (!string.IsNullOrWhiteSpace(grade))
            {
                listQuery = listQuery.Where(a => a.Grade == grade);
            }

            if (supplierId != 0)
            {
                listQuery = listQuery.Where(a => a.Suppliers.Any(x => x.Id == supplierId));
            }
           
            if (!string.IsNullOrWhiteSpace(customerName))
            {
                listQuery = listQuery.Where(a => a.Customers.Any(x => x.Name == customerName));
            }

            var products = listQuery
                .Select(a => new ProductViewModel
                {
                    Description = description,
                    Size = size,
                    Grade = grade,
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

            var pro = new ProductsAvailability
            {
                Descriptions = descriptions,
                Sizes = sizes,
                Grades = grades,
                Suppliers = suppliers,
                Customers = customers,
                Products = products
            };
            
            return View();

        }

    }
}
