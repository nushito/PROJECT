
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
               
        }
        public int Id { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string InvoiceNumber { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Grade { get; set; }
        public int Pieces { get; set; }
        public decimal Cubic { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TransportCost { get; set; }
        public decimal TerminalCharges { get; set; }
        public decimal Duty { get; set; }
        public decimal CustomsExpenses { get; set; }
        public decimal BankExpenses { get; set; }
        public decimal CostPrice { get; set; }
       
        public ICollection<string> Descriptions { get; set; }
        public ICollection<string> Sizes { get; set; }
        public ICollection<string> Grades { get; set; }
        public ICollection<AllSuppliers> Suppliers { get; set; }
        public ICollection<PurchaseProductFormModel> PurchaseProducts { get; set; } 
        
    }
}
