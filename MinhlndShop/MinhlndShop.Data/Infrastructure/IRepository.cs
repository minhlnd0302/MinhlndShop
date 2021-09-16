using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MinhlndShop.Data.Infrastructure
{

    public interface IRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll(string[] includes = null);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        T Add(T entity);
        IEnumerable<T> AddRange(IEnumerable<T> entities);
        T Update(T entity);
        IEnumerable<T> UpdateRange(IEnumerable<T> entity);
        T Remove(T entity);
        T Remove(int id);
        IEnumerable<T> RemoveRange(IEnumerable<T> entities);
        Task<int> Count(Expression<Func<T, bool>> where);
        IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null);

        Task<T> GetSingleByCondition(Expression<Func<T, bool>> expression, string[] includes = null);
        Task<IEnumerable<T>> GetMulti(Expression<Func<T, bool>> predicate, string[] includes = null);

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
