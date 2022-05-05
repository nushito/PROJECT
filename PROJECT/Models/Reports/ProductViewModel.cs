﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Models.Reports
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public string Size { get; set; }
        public string Grade { get; set; }
        public decimal Quantity { get; set; }
       
        public ProductSpecificationViewModel Specification { get; set; }
    }
}
