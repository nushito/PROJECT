using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using PROJECT.Data;
using PROJECT.Infrastructure;

namespace PROJECT.Services.MyCompany
{
    public class MycompanyService : IMycompanyService
    {
        private readonly ApplicationDbContext dbContext;
        
        public MycompanyService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public ICollection<string> GetCompany()
        {
            
                return dbContext.MyCompanies
                    .Select(x => x.Name)
                    .ToList();
         }

        
    }
}
