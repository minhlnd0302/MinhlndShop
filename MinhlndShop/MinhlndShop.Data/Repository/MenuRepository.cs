using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Model.Model;

namespace MinhlndShop.Data.Repository
{
    public interface IMenuRepository
    {

    }
    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
