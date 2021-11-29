using PROJECT.Data;
using PROJECT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Services.Documents
{
    public class DocumentService : IDocumentService
    {
        private readonly ApplicationDbContext dbContext;

        public DocumentService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int GetLastNumInvoice()
        {

            var n = dbContext.Invoices.OrderByDescending(a => a.Number).Select(a=>a.Number).FirstOrDefault();
            return n++; 
        }

        public int GetLastNumOrder()
        {
            var n = dbContext.Orders.OrderByDescending(a => a.Number).Select(a => a.Number).FirstOrDefault();
            return 0;
        }

        public int GetLastNumProforma()
        {
            var n = dbContext.Orders.OrderByDescending(a => a.Number).Select(a => a.Number).FirstOrDefault();
            return 0;
        }

        public ICollection<int> GetInvoicesNumbers(string customer)
        {
            return dbContext.Invoices.Where(x => x.Client.Name == customer)
                .Select(a=>a.Number).ToList();
        }

        public string GetDates(int number)
        {
            return dbContext.Invoices
                .Where(a => a.Number == number)
                .Select(a => a.Date.ToString())
                .FirstOrDefault();

        }

        public IEnumerable<int> GetInvoices()
        {
            throw new NotImplementedException();
        }

        
    }
}
