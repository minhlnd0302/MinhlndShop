﻿using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Model.Model;

namespace MinhlndShop.Data.Repository
{
    public interface IVisitorStatisticRepository
    {

    }
    public class VisitorStatisticRepository : RepositoryBase<VisitorStatistic>, IVisitorStatisticRepository
    {
        public VisitorStatisticRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
