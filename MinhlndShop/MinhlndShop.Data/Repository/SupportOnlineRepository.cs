using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Model.Model;

namespace MinhlndShop.Data.Repository
{
    public interface ISupportOnlineRepository
    {

    }
    public class SupportOnlineRepository : RepositoryBase<SupportOnline>, ISupportOnlineRepository
    {
        public SupportOnlineRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
