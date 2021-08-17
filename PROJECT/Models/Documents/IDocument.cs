using PROJECT.Models.Customers;
using PROJECT.Models.Products;
using PROJECT.Models.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Models.Documents
{
    public interface IDocument
    {
        public string Number { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public AddSupplierModel Supplier { get; set; }
        public AddCustomerFormModel Client { get; set; }
        public ICollection<AddProductsFormModel> Products { get; set; }
    }
}
