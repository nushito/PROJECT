
using PROJECT.Data.Models;
using PROJECT.Services.Products.Models;
using PROJECT.Services.Supplier;
using System.Collections.Generic;

namespace PROJECT.Models.Purchases
{
    public class PurchaseFormModel
    {
        public PurchaseFormModel()
        {
            Suppliers = new HashSet<AllSuppliers>();           
        }
        public int Id { get; set; }
        public int SupplierId { get; set; }
                public string InvoiceNumber { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Grade { get; set; }
        public PurchaseProductFormModel PurchaseProductFormModel { get; set; }
        public ICollection<DescriptionListModel> Descriptions { get; set; }
        public ICollection<SizeListModel> Sizes { get; set; }
        public ICollection<GradeListModel> Grades { get; set; }
        public ICollection<AllSuppliers> Suppliers { get; set; }
        public ICollection<PurchaseProductFormModel> PurchaseProducts { get; set; } 
        
    }
}
