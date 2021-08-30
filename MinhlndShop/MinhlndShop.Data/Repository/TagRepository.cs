using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Model.Model;

namespace MinhlndShop.Data.Repository
{
    public interface ITagRepository
    {

    }
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
