using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MinhlndShop.Data.Infrastructure
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : class
    {

        #region Properties
        //private MinhlndShopDbContext dataContext;
        //private readonly DbSet<T> dbSet;

        protected readonly MinhlndShopDbContext Dbcontext;
        //protected RepositoryBase(IDbFactory dbFactory)
        //{
        //    DbFactory = dbFactory;
        //    //dbSet = DbContext.Set<T>();
        //}
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }
        public RepositoryBase(IDbFactory dbFactory)
        {
            //_context = context;
            Dbcontext = Dbcontext ?? (Dbcontext = DbFactory.Init());
        }
        #endregion


        #region Implementation
        public void Add(T entity)
        {
            Dbcontext.Set<T>().Add(entity);
        }
        public void AddRange(IEnumerable<T> entities)
        {
            Dbcontext.Set<T>().AddRange(entities);
        }

        public void Update(T entitie)
        {
            Dbcontext.Set<T>().Update(entitie);
        }

        public void UpdateRange(IEnumerable<T> entities)
        {
            Dbcontext.Set<T>().UpdateRange(entities);
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return Dbcontext.Set<T>().Where(expression);
        }
        public IEnumerable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = Dbcontext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.ToList();
            } 

            return Dbcontext.Set<T>().ToList();

        }
        public T GetById(int id)
        {
            return Dbcontext.Set<T>().Find(id);
        }
        public void Remove(T entity)
        {
            Dbcontext.Set<T>().Remove(entity);
        }

        public void Remove(int id)
        {
            var entity = Dbcontext.Set<T>().Find(id);
            Dbcontext.Set<T>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<T> entities)
        {
            Dbcontext.Set<T>().RemoveRange(entities);
        }

        public int Count(Expression<Func<T, bool>> where)
        {
            return Dbcontext.Set<T>().Count();
        }

        public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null)
        {
            int skipCount = index * size;
            IEnumerable<T> _resetSet;

            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = Dbcontext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                _resetSet = predicate != null ? query.Where<T>(predicate).AsQueryable() : query.AsQueryable();
            }
            else
            {
                _resetSet = predicate != null ? Dbcontext.Set<T>().Where<T>(predicate).AsQueryable() : Dbcontext.Set<T>().AsQueryable();
            }

            _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
            total = _resetSet.Count();
            return _resetSet;
        }

        public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = Dbcontext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.FirstOrDefault(expression);
            }
            return Dbcontext.Set<T>().FirstOrDefault(expression);
        }

        public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        {
            //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
            if (includes != null && includes.Count() > 0)
            {
                var query = Dbcontext.Set<T>().Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.Where<T>(predicate).ToList();
            }

            return Dbcontext.Set<T>().Where<T>(predicate).ToList();
        }


        //public virtual void Add(T entity)
        //{
        //    //return dbSet.Add(entity);
        //    if (entity == null)
        //    {
        //        throw new ArgumentNullException("entity");
        //    }
        //    dbSet.Add(entity);
        //    //DbContext.SaveChanges();
        //}

        //public virtual void Update(T entity)
        //{
        //    dbSet.Attach(entity);
        //    dataContext.Entry(entity).State = EntityState.Modified;
        //}

        //public virtual T Delete(T entity)
        //{
        //    return dbSet.Remove(entity);
        //}
        //public virtual T Delete(int id)
        //{
        //    //var entity = dbSet.Find(id);
        //    //return dbSet.Remove(entity);
        //    if (id == null)
        //    {
        //        throw new ArgumentNullException("entity");
        //    }
        //    dbSet.Remove(id);
        //    //context.SaveChanges();
        //}
        //public virtual void DeleteMulti(Expression<Func<T, bool>> where)
        //{
        //    IEnumerable<T> objects = dbSet.Where<T>(where).AsEnumerable();
        //    foreach (T obj in objects)
        //        dbSet.Remove(obj);
        //}

        //public virtual T GetSingleById(int id)
        //{
        //    return dbSet.Find(id);
        //}

        //public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where, string includes)
        //{
        //    return dbSet.Where(where).ToList();
        //}

        //public virtual int Count(Expression<Func<T, bool>> where)
        //{
        //    return dbSet.Count(where);
        //}

        //public IEnumerable<T> GetAll(string[] includes = null)
        //{
        //    //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
        //    if (includes != null && includes.Count() > 0)
        //    {
        //        var query = dataContext.Set<T>().Include(includes.First());
        //        foreach (var include in includes.Skip(1))
        //            query = query.Include(include);
        //        return query.AsQueryable();
        //    }

        //    return dataContext.Set<T>().AsQueryable();
        //}

        //public T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null)
        //{
        //    if (includes != null && includes.Count() > 0)
        //    {
        //        var query = dataContext.Set<T>().Include(includes.First());
        //        foreach (var include in includes.Skip(1))
        //            query = query.Include(include);
        //        return query.FirstOrDefault(expression);
        //    }
        //    return dataContext.Set<T>().FirstOrDefault(expression);
        //}

        //public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null)
        //{
        //    //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
        //    if (includes != null && includes.Count() > 0)
        //    {
        //        var query = dataContext.Set<T>().Include(includes.First());
        //        foreach (var include in includes.Skip(1))
        //            query = query.Include(include);
        //        return query.Where<T>(predicate).AsQueryable<T>();
        //    }

        //    return dataContext.Set<T>().Where<T>(predicate).AsQueryable<T>();
        //}

        //public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> predicate, out int total, int index = 0, int size = 20, string[] includes = null)
        //{
        //    int skipCount = index * size;
        //    IQueryable<T> _resetSet;

        //    //HANDLE INCLUDES FOR ASSOCIATED OBJECTS IF APPLICABLE
        //    if (includes != null && includes.Count() > 0)
        //    {
        //        var query = dataContext.Set<T>().Include(includes.First());
        //        foreach (var include in includes.Skip(1))
        //            query = query.Include(include);
        //        _resetSet = predicate != null ? query.Where<T>(predicate).AsQueryable() : query.AsQueryable();
        //    }
        //    else
        //    {
        //        _resetSet = predicate != null ? dataContext.Set<T>().Where<T>(predicate).AsQueryable() : dataContext.Set<T>().AsQueryable();
        //    }

        //    _resetSet = skipCount == 0 ? _resetSet.Take(size) : _resetSet.Skip(skipCount).Take(size);
        //    total = _resetSet.Count();
        //    return _resetSet.AsQueryable();
        //}

        //public bool CheckContains(Expression<Func<T, bool>> predicate)
        //{
        //    return dataContext.Set<T>().Count<T>(predicate) > 0;
        //}
        #endregion
    }
}
