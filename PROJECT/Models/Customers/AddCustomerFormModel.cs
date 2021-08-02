using System.ComponentModel.DataAnnotations;

namespace PROJECT.Models.Customers
{
    public class AddCustomerFormModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(11)]
        public string VAT { get; set; }
        [Required]
        [StringLength(11)]
        public string EIK { get; set; }
        [Display(Name ="Representative person")]
        public string RepresentativePerson { get; set; }
        [Required]

        public Address ClientAddress { get; set; }

        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

    }
}
