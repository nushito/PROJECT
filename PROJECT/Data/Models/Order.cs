using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Data.Models
{
    public class Order
    {
        public Order()
        {
            Products = new HashSet<Product>();
        }
       
        public int Id { get; init; }
        [Required]
        public string Number { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public int ClientId { get; set; }
        public Customer Customer { get; set; }
        public int MyCompanyId { get; set; }
        public MyCompany MyCompany { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public decimal Amount { get; set; }
        public decimal SubTotal { get; set; }
        public decimal Total { get; set; }
    }
}
