using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Model.Model;

namespace MinhlndShop.Data.Repository
{
    public interface IPageRepository
    {

    }
    public class PageRepository : RepositoryBase<Page>, IPageRepository
    {
        public PageRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
