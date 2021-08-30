using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Model.Model;

namespace MinhlndShop.Data.Repository
{
    public interface IPostRepository
    {

    }
    public class PostRepository : RepositoryBase<Post>, IPostRepository
    {
        public PostRepository (DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
