using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJECT.Models.Products;
using PROJECT.Services;
using PROJECT.Services.MyCompany;
using PROJECT.Services.Products;
using System.Linq;

namespace PROJECT.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService service;
        private readonly ISupplierService supplierService;

        public ProductsController(IProductsService service, ISupplierService supplierService)
        {
            this.service = service;
            this.supplierService = supplierService;
        }

        [Authorize]
        public IActionResult AddProduct()
        {
            return View(new AddProductsFormModel 
            { 
                SupplierNames = supplierService.GetSuppliers()
                                .Select(a=>a.Name)
                                .ToList() 
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddProduct(AddProductsFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            service.Add(model.Id, model.ProductDescription, model.Size, model.Grade, model.SupplierName);

            return RedirectToAction("Index","Home");
        }

       public IActionResult All()
        {
            return RedirectToAction("Home", "Index");
        }
    }
}
