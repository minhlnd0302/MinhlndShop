using System;
using System.Collections.Generic;
using System.Text;

namespace MinhlndShop.Data.Infrastructure
{
    class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private MinhlndShopDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public MinhlndShopDbContext DbContext
        {
            get
            {
                return dbContext ?? (dbContext = dbFactory.Init());
            }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }
    }
}
