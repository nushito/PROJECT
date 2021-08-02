﻿using InvoiceAndStockModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PROJECT.Data;
using PROJECT.Models;
using PROJECT.Models.Customers;

namespace PROJECT.Controllers
{
    public class CustomersController: Controller
    {
        private readonly ApplicationDbContext dbContext;

        public CustomersController(ApplicationDbContext dbContex)
        {
            this.dbContext = dbContex;

        }

        public IActionResult Add()
        {
            return View();

        }

        [Authorize]
        [HttpPost]
        public IActionResult Add(AddCustomerFormModel model)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home");
            }

            var customer = new Customer
            {
              ClientAddress = model.ClientAddress,
               Email = model.Email,
               Name = model.Name,
              VAT = model.VAT,
              EIK = model.EIK
            };

            this.dbContext.Clients.Add(customer);
            this.dbContext.SaveChanges();

            return View();
        }
    }
}
