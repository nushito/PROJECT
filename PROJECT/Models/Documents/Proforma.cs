using PROJECT.Models.Customers;
using PROJECT.Models.Products;
using PROJECT.Models.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Models.Documents
{
    public class Proforma : IDocument
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public AddSupplierModel Supplier { get; set; }
        public AddCustomerFormModel Client { get; set; }
        public ICollection<AddProductsFormModel> Products { get; set; }
    }
}
