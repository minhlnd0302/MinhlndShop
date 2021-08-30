using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Model.Model;

namespace MinhlndShop.Data.Repository
{
    public interface ISlideRepository
    {

    }
    public class SlideRepository : RepositoryBase<Slide>, ISlideRepository
    {
        public SlideRepository(DbFactory dbFactory ): base(dbFactory)
        {

        }
    }
}
