using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Models.Reports
{
    public class ProductViewModel
    {
      
        public string ProductDescription { get; set; }
        public string Size { get; set; }
        public string Grade { get; set; }
        public decimal CostPrice { get; set; }
        public decimal  SoldPrice { get; set; }
        public decimal Income { get; set; }
        public decimal Cubic { get; set; }
    }
}
