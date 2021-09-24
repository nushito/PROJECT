﻿using PROJECT.Models.Customers;
using PROJECT.Models.Products;
using PROJECT.Models.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Models.Documents
{
    public class OrderModel : IDocument
    {
        public int Id { get; set; }
        public int Number { get ; set ; }
        public DateTime Date { get; set; }
        [Display(Name = "Customer")]
        public AddCustomerFormModel Client { get; set; }
        public ICollection<AddProductsFormModel> Products { get; set; }
        public int SellerId { get ; set; }
        public SupplierModel Seller { get ; set ; }
        public int ClientId { get ; set ; }
        public ICollection<string> Customers { get ; set; }
        public decimal SubTotal { get ; set ; }
        public decimal Total { get; set ; }
        public int VatPercent { get; set; }
        public decimal Amount { get ; set ; }
    }
}
