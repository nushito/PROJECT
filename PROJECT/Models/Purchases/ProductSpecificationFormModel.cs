
using PROJECT.Services.Products.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Models.Purchases
{
    public class ProductSpecificationFormModel
    {
       
        [Required]
        public int Pieces { get; set; }
        public decimal Cubic { get; set; }
        public decimal Price { get; set; }
        public decimal TransportCost { get; set; }
        public decimal TerminalCharges { get; set; }
        public decimal Duty { get; set; }
        public decimal CustomsExpenses { get; set; }
        public decimal BankExpenses { get; set; }
        public decimal CostPrice { get; set; }
 


    }
}
