using MinhlndShop.Data;
using MinhlndShop.Data.Infrastructure;
using MinhlndShop.Data.Repositories;
using MinhlndShop.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhlndShop.Service
{ 
    public interface IUserService 
    {
        //User GetByUserName(string userName);
        User Login(string userName, string password); 
        User CreateUser(User user);

        Task Save();
        Task<User> GetUserById(int userId);
    }
    public class UserService : IUserService
    {
        IUserRepository _userRepository;
        IUnitOfWork _unitOfWork;
        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            this._userRepository = userRepository;
            this._unitOfWork = unitOfWork;
        }

        public User CreateUser(User user)
        {
            return _userRepository.Add(user);
        }

        public async Task<User> GetUserById(int userId)
        {
            return await _userRepository.GetById(userId);
        }

        public User Login(string userName, string password)
        {
            User user = _userRepository.FindUserByUserName(userName);
            if (user == null || user.Password != password)
            {
                return null;
            }
            return user;
        }

        public Task Save()
        {
            return _unitOfWork.CommitAsync();
        }
    }
}
