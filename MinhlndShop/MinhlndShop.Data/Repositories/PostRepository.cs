using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Model.Model;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MinhlndShop.Data.Repository
{
    //public interface IPostRepository : IRepository<Post>
    //{
    //    IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow);
    //}
    //public class PostRepository : RepositoryBase<Post>, IPostRepository
    //{
    //    public PostRepository (IDbFactory dbFactory) : base(dbFactory)
    //    {

    //    }

    //    public IEnumerable<Post> GetAllByTag(string tag, int pageIndex, int pageSize, out int totalRow)
    //    {
    //        var query = from p in Dbcontext.Posts
    //                    join pt in Dbcontext.PostTags
    //                    on p.ID equals pt.PostID
    //                    where pt.TagID == tag && p.Status
    //                    orderby p.CreateDate descending
    //                    select p;

    //        totalRow = query.Count();
    //        query = query.Skip((pageIndex - 1) * pageSize).Take(pageSize);
    //        return query;
    //    }
    //}
}
