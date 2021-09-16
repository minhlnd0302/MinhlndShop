using MinhlndShop.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhlndShop.Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {  
        private readonly IDbFactory dbFactory;
        private MinhlndShopDbContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public MinhlndShopDbContext DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }
        //public UnitOfWork(MinhlndShopDbContext minhlndShopDbContext) 
        //{
        //    _dbContext = minhlndShopDbContext;
        //    //Errors = new ErrorRepository(_dbContext);
        //    Users = new UserRepository(_dbContext);
        //}

        //public IErrorRepository Errors { get; private set; }

        //public IUserRepository Users { get; private set; }
         

        //public MinhlndShopDbContext DbContext
        //{
        //    get
        //    {
        //        return dbContext ?? (dbContext = dbFactory.Init());
        //    }
        //} 
        public Task CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        //public void Dispose()
        //{
        //    dbContext.DisposeAsync();
        //}
    }
}
