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
        public async Task<string> Login(LoginViewModel loginViewModel)
        {
            return await _userRepository.Login(loginViewModel);
        }
        public async Task<User?> Register(RegisterViewModel registerViewModel)
        {
            // Kiểm tra xem username hoặc email đã tồn tại trong database chưa
            //Tạo ra đối tượng User từ RegisterViewModel            
            var existingUserByUsername = await _userRepository
                        .GetByUsername(registerViewModel.Username ?? "");
            if (existingUserByUsername != null)
            {
                throw new ArgumentException("Username already exists");
            }

            var existingUserByEmail = await _userRepository
                .GetByEmail(registerViewModel.Email);
            if (existingUserByEmail != null)
            {
                throw new ArgumentException("Email already exists");
            }

            return await _userRepository.Create(registerViewModel);
        }

        public Task<User?> GetById(int id)
        {
            return _userRepository.GetById(id);
        }

        public Task<User?> GetByEmail(string email)
        {
            return _userRepository.GetByEmail(email);
        }
        public Task<User?> GetByUsername(string name)
        {
            return _userRepository.GetByUsername(name);
        }
        public Task<User?> UpdateById(int id, User user)
        {
            return _userRepository.UpdateById(id, user);
        }
        public Task<User?> DeleteById(int id)
        {
            return _userRepository.DeleteById(id);
        }

    }
}
