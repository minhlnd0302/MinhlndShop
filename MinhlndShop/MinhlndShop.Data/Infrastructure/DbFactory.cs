using System;
using System.Collections.Generic;
using System.Text;

namespace MinhlndShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private MinhlndShopDbContext dbContext;

        public MinhlndShopDbContext Init()
        {
            return dbContext ?? (dbContext = new MinhlndShopDbContext());
        }

        protected override void DisposeCore()
        {
            if(dbContext!= null)
            {
                dbContext.Dispose();
            }
        }
    }
}
