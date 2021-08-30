using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Model.Model;

namespace MinhlndShop.Data.Repository
{
    public interface IOrderDetailRepository
    {

    }
    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(DbFactory dbFactory) : base(dbFactory)
        { 

        }
    }
}
