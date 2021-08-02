﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROJECT.Data.Models
{
    public class Currency
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public ICollection<BankDetails> BankDetails { get; set; } 
    }
}
