using Microsoft.EntityFrameworkCore;
using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhlndShop.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User FindUserByUserName(string userName);
    }
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public User FindUserByUserName(string userName)
        {
            return this.DbContext.Users.Where(u => u.UserName == userName).FirstOrDefault();
        }
    }
}
