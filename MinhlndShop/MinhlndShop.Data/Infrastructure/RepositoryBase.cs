using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MinhlndShop.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {

        #region Properties 
        protected  MinhlndShopDbContext dataContext;
        protected readonly DbSet<T> DbSetEntity;
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }
        protected MinhlndShopDbContext DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
        public RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            DbSetEntity = DbContext.Set<T>();

            //Dbcontext = minhlndShopDbContext;
            //DbSetEntity = Dbcontext.Set<T>();
        }

        #endregion

        #region Implementation

        public async Task<T> GetById(int id)
        {
            return await DbSetEntity.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = DbSetEntity.Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return await query.ToListAsync();
            }

            return await DbSetEntity.ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await DbSetEntity.Where(predicate).ToListAsync();
        }

        public T Add(T entity)
        {
            DbSetEntity.Add(entity);
            return entity;
        }

        public IEnumerable<T> AddRange(IEnumerable<T> entities)
        {
            DbSetEntity.AddRange();
            return entities;
        }

        public T Update(T entity)
        {
            DbSetEntity.Update(entity);
            return entity;
        }

        public IEnumerable<T> UpdateRange(IEnumerable<T> entities)
        {
            DbSetEntity.UpdateRange(entities);
            return entities;
        }

        public T Remove(T entity)
        {
            DbSetEntity.Remove(entity);
            return entity;
        }

        public T Remove(int id)
        {
            T entity = DbSetEntity.Find(id);
            DbSetEntity.Remove(entity);
            return entity;
        }

        public IEnumerable<T> RemoveRange(IEnumerable<T> entities)
        {
            DbSetEntity.RemoveRange(entities);
            return entities;
        }

        public async Task<int> Count(Expression<Func<T, bool>> where)
        {
            return await DbSetEntity.CountAsync();
        }

        public async Task<T> GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = DbSetEntity.Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return await query.FirstOrDefaultAsync(expression);
            }
            return await DbSetEntity.FirstOrDefaultAsync(expression);
        }

        public async Task<IEnumerable<T>> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = DbSetEntity.Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return await query.Where<T>(predicate).ToListAsync();
            }

            return await DbSetEntity.Where<T>(predicate).ToListAsync();
        }

        public IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            int skipCount = index * size;
            IEnumerable<T> _resetSet;

            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = DbSetEntity.Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                _resetSet = filter != null ? query.Where<T>(filter).AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet = filter != null ? DbSetEntity.Where<T>(filter).AsQueryable() : DbSetEntity.AsQueryable();
            }

            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet;
        }
       
         
        //public void Add(T entity)
        //{
        //   Dbcontext.Set<T>().Add(entity);
        //}
        //public async Task AddRange(IEnumerable<T> entities)
        //{
        //    await Dbcontext.Set<T>().AddRangeAsync(entities);
        //}

        //public void Update(T entity)
        //{
        //    Dbcontext.Set<T>().Update(entity);
        //}

        //public void UpdateRange(IEnumerable<T> entities)
        //{
        //    Dbcontext.Set<T>().UpdateRange(entities);
        //}
        ////public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        ////{
        ////    return Dbcontext.Set<T>().Where(expression);
        ////}
        //public async Task<IEnumerable<T>> GetAll(string[] includes = null)
        //{
        //    if (includes != null && includes.Count() > 0)
        //    {
        //        var query = Dbcontext.Set<T>().Include(includes.First());
        //        foreach (var include in includes.Skip(1))
        //            query = query.Include(include);
        //        return await query.ToListAsync();
        //    }

        //    return await Dbcontext.Set<T>().ToListAsync();

        //}
        //public async Task<T> GetById(int id)
        //{
        //    return await Dbcontext.Set<T>().FindAsync(id);
        //}
        //public void Remove(T entity)
        //{
        //    Dbcontext.Set<T>().Remove(entity);
        //}

        //public void Remove(int id)
        //{
        //    var entity = Dbcontext.Set<T>().Find(id);
        //    Dbcontext.Set<T>().Remove(entity);
        //}
        //public void RemoveRange(IEnumerable<T> entities)
        //{
        //    Dbcontext.Set<T>().RemoveRange(entities);
        //}

        //public async Task<int> Count(Expression<Func<T, bool>> where)
        //{
        //    return await Dbcontext.Set<T>().Count();
        //}

        //public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null)
        //{
        //    int skipCount = index * size;
        //    IEnumerable<T> _resetSet;

        //    HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
        //    if (includes != null && includes.Count() > 0)
        //    {
        //        var query = Dbcontext.Set<T>().Include(includes.First());
        //        foreach (var include in includes.Skip(1))
        //            query = query.Include(include);
        //        _resetSet = predicate != null ? query.Where<T>(predicate).AsQueryable() : query.AsQueryable();
        //    }
        //    else
        //    {
        //        _resetSet = predicate != null ? Dbcontext.Set<T>().Where<T>(predicate).AsQueryable() : Dbcontext.Set<T>().AsQueryable();
        //    }

        //    _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
        //    total = _resetSet.Count();
        //    return _resetSet;
        //}

        //public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        //{
        //    if (includes != null && includes.Count() > 0)
        //    {
        //        var query = Dbcontext.Set<T>().Include(includes.First());
        //        foreach (var include in includes.Skip(1))
        //            query = query.Include(include);
        //        return query.FirstOrDefault(expression);
        //    }
        //    return Dbcontext.Set<T>().FirstOrDefault(expression);
        //}

        //public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        //{
        //    //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
        //    if (includes != null && includes.Count() > 0)
        //    {
        //        var query = Dbcontext.Set<T>().Include(includes.First());
        //        foreach (var include in includes.Skip(1))
        //            query = query.Include(include);
        //        return query.Where<T>(predicate).ToList();
        //    }

        //    return Dbcontext.Set<T>().Where<T>(predicate).ToList();
        //}



        #endregion
    }
}
