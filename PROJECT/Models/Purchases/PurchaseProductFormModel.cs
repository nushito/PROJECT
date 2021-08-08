
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Models.Purchases
{
    public class PurchaseProductFormModel
    {
        public int Id { get; init; }
        public string ProductDescription { get; set; }       
        public string Size { get; set; }
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
        public string Unit { get; set; }

        public int SupplierId { get; set; }
    }
}
