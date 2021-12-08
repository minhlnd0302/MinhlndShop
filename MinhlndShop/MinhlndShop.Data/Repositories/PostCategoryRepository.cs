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
    public class PostCategoryRepository : RepositoryBase<PostCategory>, IPostCategoryRepository
    {
        public PostCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
