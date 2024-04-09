using StockAppWebAPI11.Models;
using StockAppWebAPI11.ViewModels;

namespace StockAppWebAPI11.Repository
{
    public interface IUserRepository
    {
        Task<User?> Create(RegisterViewModel registerViewModel);
        Task<User?> GetById(int id);
        Task<User?> GetByUsername(string username);
        Task<User?> GetByEmail(string email);
        Task<User?> UpdateById(int id, User user);
        Task<User?> DeleteById(int id);
        Task<string> Login(LoginViewModel loginViewModel);
    }
}
