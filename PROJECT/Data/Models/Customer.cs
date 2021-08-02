using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            Invoices = new HashSet<Document>();
            Orders = new HashSet<Order>();
        }
       
        public int Id { get; init; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(11)]
        public string EIK { get; set; }
        [Required]
        [StringLength(11)]
        public string VAT { get; set; }
        public string RepresentativePerson { get; set; }
        public int AddressId { get; set; }
        [Required]
        public Address ClientAddress { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        public ICollection<Document> Invoices { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
