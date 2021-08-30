using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MinhlndShop.Data.Infrastructure
{
    public interface IRepository <T> where T : class
    {
        T GetById(int id);
        IEnumerable<T> GetAll(string[] includes = null);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        void Add(T entity);
        void AddRange(IEnumerable<T> entities); 
        void Update(T entity);
        void UpdateRange(IEnumerable<T> entity);
        void Remove(T entity);
        void Remove(int id);
        void RemoveRange(IEnumerable<T> entities);

        int Count(Expression<Func<T, bool>> where);
        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        T GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);
        IEnumerable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        //void Add(T entity);

        //void Update(T entity);
        //void Delete(T entity);
        //void DeleteMulti(Expression<Func<T, bool>> where);

        //T GetSingleById(int id);



        //IQueryable<T> GetAll(string[] includes = null);
        //IQueryable<T> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

        //IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        //int Count(Expression<Func<T, bool>> where);
        //bool CheckContains(Expression<Func<T, bool>> predicate);

    }
}
