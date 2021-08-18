using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using PROJECT.Models.Customers;
using PROJECT.Models.Products;

namespace PROJECT.Models.Documents
{
    public interface IDocument
    {
        public int Number { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int SellerId { get; set; }
        public SupplierModel Seller { get; set; }

        public int ClientId { get; set; }
        public AddCustomerFormModel Client { get; set; }
        public ICollection<AddCustomerFormModel> Customers { get; set; }
        public ICollection<AddProductsFormModel> Products { get; set; }
    }
}
