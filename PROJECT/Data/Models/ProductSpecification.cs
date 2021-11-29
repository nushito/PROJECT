namespace PROJECT.Data.Models
{
    public class ProductSpecification
    {
        public int Id { get; set; }
        public int Pieces { get; set; } 
        public decimal Cubic { get; set; }
        public decimal Price { get; set; }
        public decimal TransportCost { get; set; }
        public decimal TerminalCharges { get; set; }
        public decimal CustomsExpenses { get; set; }
        public decimal Duty { get; set; }
        public decimal BankExpenses { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SoldPrice { get; set; }
        public decimal Income { get; set; }
        public int InvoiceNumber { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
