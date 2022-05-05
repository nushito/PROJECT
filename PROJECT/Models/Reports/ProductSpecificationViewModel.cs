using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Models.Reports
{
    public class ProductSpecificationViewModel
    {
        public int Pieces { get; set; }
 
        public decimal Cubic { get; set; }
        public decimal Price { get; set; }
        public decimal TransportCost { get; set; }
        public decimal TerminalCharges { get; set; }
        public decimal CustomsExpenses { get; set; }
        public decimal Duty { get; set; }
        public decimal BankExpenses { get; set; }
        public decimal CostPrice { get; set; }
        public decimal  Income { get; set; }
        public string PurchaseNumber { get; set; }
    }
}
