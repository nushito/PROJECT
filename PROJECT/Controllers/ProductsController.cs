using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJECT.Models.Products;
using PROJECT.Models.Purchases;
using PROJECT.Services.MyCompany;
using PROJECT.Services.Products;

namespace PROJECT.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductsService service;

        public ProductsController(IProductsService service)
        {
            this.service = service;
        }

        [Authorize]
        public IActionResult AddProduct()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddProduct(AddProductsFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            service.Add(model.Id, model.ProductDescription, model.Size, model.Grade);

            return RedirectToAction("Index","Home");
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(ProductFormModel model)
        {
            return View();
        }

    }
}
