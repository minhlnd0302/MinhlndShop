using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MinhlndShop.Data.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
