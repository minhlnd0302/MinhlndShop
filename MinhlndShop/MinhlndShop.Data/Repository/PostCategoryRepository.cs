using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MinhlndShop.Data.Repository
{
    public interface IPostCategoryRepository : IRepository<PostCategory>
    {

    }
    public class PostCategoryRepository : RepositoryBase<PostCategory>, IPostRepository
    {
        public PostCategoryRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }

        public void Add(Post entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<Post> entities)
        {
            throw new NotImplementedException();
        }

        public int Count(Expression<Func<Post, bool>> where)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> Find(Expression<Func<Post, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetMulti(Expression<Func<Post, bool>> predicate, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetMultiPaging(Expression<Func<Post, bool>> filter, out int total, int index = 0, int size = 50, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public Post GetSingleByCondition(Expression<Func<Post, bool>> expression, string[] includes = null)
        {
            throw new NotImplementedException();
        }

        public void Remove(Post entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<Post> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(Post entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateRange(IEnumerable<Post> entity)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Post> IRepository<Post>.GetAll(string[] includes)
        {
            throw new NotImplementedException();
        }

        Post IRepository<Post>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
