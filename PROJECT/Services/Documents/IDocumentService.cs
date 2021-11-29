using PROJECT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Services.Documents
{
    public interface IDocumentService
    {
        public int GetLastNumInvoice();
        public int GetLastNumOrder();
        public int GetLastNumProforma();
        public IEnumerable<int> GetInvoices();

        public string GetDates(int number);

    }
}
