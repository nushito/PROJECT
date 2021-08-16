
using PROJECT.Services.Products.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Models.Purchases
{
    public class PurchaseProductFormModel
    {
        public int Id { get; set; }
        public int DescriptionId { get; set; }
        public string Description { get; set; }
        public int SizeId { get; set; }
        public string Size { get; set; }
        public int GradeId { get; set; }
        [Required]
        public string Grade { get; set; }
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
        public int SupplierId { get; set; }
        public ICollection<string> Sizes { get; set; }
        public ICollection<string> Grades { get; set; }
        public ICollection<string> Descriptions { get; set; }


    }
}
