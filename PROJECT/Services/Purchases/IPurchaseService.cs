using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJECT.Services.Purchases
{
    public interface IPurchaseService
    {
        public int Create(
            int supplierId, string date, string invoiceNumber
           );

        public int SaveProduct(string productDescription,
            string size, string grade, int pieces,
            decimal cubic, decimal purchasePrice, decimal transportCost,
            decimal terminalCharges, decimal duty, decimal customsExpenses, decimal bankExpenses);

    }
}
