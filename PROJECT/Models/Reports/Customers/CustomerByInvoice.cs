using PROJECT.Data.Models;
using PROJECT.Models.Reports.Customers;
using System.Collections.Generic;

namespace PROJECT.Models.Reports
{
    public class CustomerByInvoice
    {
        public string CustomerName { get; set; }
        public IEnumerable<string> CustomerNames { get; set; }
        public int InvoiceNum { get; set; }
        public IEnumerable<int> InvoiceNumbers { get; set; }
        public string Date { get; set; }
        public IEnumerable<DocumentsSelection> Invoices { get; set; }
       // public IEnumerable<DocumentsSelection> Orders { get; set; }

    }
}
