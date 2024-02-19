using StockAppWebAPI1.Models;
using StockAppWebAPI1.Repository;
using StockAppWebAPI1.ViewModels;

namespace StockAppWebAPI1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<User?> Register(RegisterViewModel registerViewMode)
        {
            return _userRepository.Create(registerViewMode);
        }

        public Task<User?> GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public Task<User?> GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }


    }
}
