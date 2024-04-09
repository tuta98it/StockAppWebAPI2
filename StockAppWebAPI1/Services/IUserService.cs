using StockAppWebAPI11.Models;
using StockAppWebAPI11.ViewModels;

namespace StockAppWebAPI11.Services
{
    public interface IUserService
    {
        Task<User?> Register(RegisterViewModel registerViewModel);
        Task<User?> GetUserByUsername(string username);
        Task<User?> GetUserByEmail(string email);
        Task<User?> GetUserById(int id);
        Task<User?> UpdateUserById(int id, User user);
        Task<User?> DeleteUserById(int id);
        Task<string> Login(LoginViewModel loginViewModel);
    }
}
