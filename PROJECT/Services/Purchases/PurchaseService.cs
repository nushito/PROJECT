using PROJECT.Data;
using PROJECT.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace PROJECT.Services.Purchases
{
    public class PurchaseService : IPurchaseService
    {
        private readonly ApplicationDbContext dbContext;
        public PurchaseService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<string> AllPurchases()
        {
            return dbContext.Purchases
                .Select(a => a.InvoiceNumber)
                .ToList();
        }

        public int Create( int supplierId, string dateInput, string invoiceNumber
           )
        {
            

           var purchase = new Purchase
            {
                Date = Convert.ToDateTime(dateInput, System.Globalization.CultureInfo.GetCultureInfo("bg-BG").DateTimeFormat),
                InvoiceNumber = invoiceNumber,
                SupplierId = supplierId,
                Supplier = dbContext.Suppliers.Find(supplierId)
            };

           

            dbContext.Purchases.Add(purchase);
        
            dbContext.SaveChanges();
            return purchase.Id;

        }

      
        //public int SaveProduct( 
        //    string productDescription, 
        //    string size, string grade, 
        //    int pieces, decimal cubic, 
        //    decimal purchasePrice, decimal transportCost, 
        //    decimal terminalCharges, decimal duty, decimal customsExpenses, decimal bankExpenses)
        //{
        //    //Loop through the forms

        //    Product product = null;

        //    if ((productDescription.ToString() != null) && (size.ToString() != null)
        //            && (grade.ToString() != null) && (pieces != 0) && (cubic != 0) &&
        //            (purchasePrice != 0) && (transportCost != 0) && (terminalCharges != 0) && (duty != 0) &&
        //            (customsExpenses != 0) && (bankExpenses != 0))
        //    {
        //         product = this.dbContext.Products
        //            .Where(a => a.Description.ToLower() == productDescription.ToLower()
        //        && a.Size.ToLower() == size.ToLower()
        //        && a.Grade.ToLower() == grade.ToLower())
        //            .FirstOrDefault();
        //        //  _Client.Add(new Client { ClientName = ClientName, Email = EMail });

        //        var productSpecification = new ProductSpecification
        //        {
        //            Pieces = pieces,
        //            Cubic = cubic,
        //            Price = purchasePrice,
        //            TransportCost = transportCost,
        //            TerminalCharges = terminalCharges,
        //            Duty = duty,
        //            CustomsExpenses = customsExpenses,
        //            BankExpenses = bankExpenses,
        //        };
        //        product.ProductSpecifications.Add(productSpecification);
        //    }

        //    return product.Id;
        //}


    }
}
