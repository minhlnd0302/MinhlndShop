﻿using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Model.Model;

namespace MinhlndShop.Data.Repository
{
    public interface IOrderRepository
    {

    }
    public class OrderRepository : RepositoryBase<Order>,IOrderRepository
    {
        public OrderRepository(DbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
