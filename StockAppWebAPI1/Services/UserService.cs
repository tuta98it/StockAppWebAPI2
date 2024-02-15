using StockAppWebAPI1.Models;
using StockAppWebAPI1.Repository;

namespace StockAppWebAPI1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<User> Register(User user)
        {
            return _userRepository.Create(user);
        }
    }
}
