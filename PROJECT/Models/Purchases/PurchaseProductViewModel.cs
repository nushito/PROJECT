using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PROJECT.Models.Purchases
{
    public class PurchaseProductViewModel
    {
        public int SupplierId { get; set; }
        public int Id { get; set; }
        public int DescriptionId { get; set; }
        public string Description { get; set; }
        public int SizeId { get; set; }
        public string Size { get; set; }
        public int GradeId { get; set; }
        [Required]
        public string Grade { get; set; }

        public ICollection<string> Sizes { get; set; }
        public ICollection<string> Grades { get; set; }
        public ICollection<string> Descriptions { get; set; }
        public PurchaseProductFormModel PurchaseProductFormModel { get; set; }


    }
}
