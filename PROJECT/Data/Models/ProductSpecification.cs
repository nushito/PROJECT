using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Data.Models
{
    public class ProductSpecification
    {
        public int Id { get; set; }
        public int Pieces { get; set; }
        [Required]
        public decimal Cubic { get; set; }
        public decimal Price { get; set; }
        public decimal TransportCost { get; set; }
        public decimal TerminalCharges { get; set; }
        public decimal CustomsExpenses { get; set; }
        public decimal Duty { get; set; }
        public decimal BankExpenses { get; set; }
    }
}
