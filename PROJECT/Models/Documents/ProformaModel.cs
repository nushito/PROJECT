using PROJECT.Models.Customers;
using PROJECT.Models.Products;
using PROJECT.Models.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Models.Documents
{
    public class ProformaModel : IDocument
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        [Display(Name = "Customer")]
        public AddCustomerFormModel Client { get; set; }
        public ICollection<AddProductsFormModel> Products { get; set; }
        public int SellerId { get; set; }
        public SupplierModel Seller { get; set; }
        public int ClientId { get; set; }
        public ICollection<AddCustomerFormModel> Customers { get; set; }
    }
}
