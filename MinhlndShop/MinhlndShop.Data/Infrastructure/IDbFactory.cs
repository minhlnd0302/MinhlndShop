using System;
using System.Collections.Generic;
using System.Text;

namespace MinhlndShop.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        MinhlndShopDbContext Init();
    }
}
