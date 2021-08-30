using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Model.Model;
using System.Collections.Generic;
using System.Linq;

namespace MinhlndShop.Data.Repository
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }
    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    { 
        public ProductCategoryRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }

        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.Dbcontext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}
