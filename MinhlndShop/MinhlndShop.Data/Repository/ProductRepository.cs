using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Model.Model;

namespace MinhlndShop.Data.Repository
{
    public interface IProductRepository
    {

    }
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    { 
        public ProductRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }

    }
}
