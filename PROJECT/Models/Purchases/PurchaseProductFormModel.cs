
using PROJECT.Services.Products.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Models.Purchases
{
    public class PurchaseProductFormModel
    {
        public int Id { get; init; }
        public int DescriptionId { get; set; }
        public string ProductDescription { get; set; }
        public int SizeId { get; set; }
        public string Size { get; set; }
        public int GradeId { get; set; }
        [Required]
        public string Grade { get; set; }
        [Required]
        public int Pieces { get; set; }
        public decimal Cubic { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal TransportCost { get; set; }
        public decimal TerminalCharges { get; set; }
        public decimal Duty { get; set; }
        public decimal CustomsExpenses { get; set; }
        public decimal BankExpenses { get; set; }
        public decimal CostPrice { get; set; }
        public int SupplierId { get; set; }
        public ICollection<SizeListModel> Sizes { get; set; }
        public ICollection<GradeListModel> Grades { get; set; }
        public ICollection<DescriptionListModel> Descriptions { get; set; }


    }
}
