using StockAppWebAPI1.Models;
using StockAppWebAPI1.ViewModels;

namespace StockAppWebAPI1.Services
{
    public interface IUserService
    {
        Task<User?> Register(RegisterViewModel registerViewModel);
        Task<User?> GetByUsername(string username);
        Task<User?> GetByEmail(string email);
        Task<User?> GetById(int id);
        Task<User?> UpdateById(int id, User user);
        Task<User?> DeleteById(int id);
    }
}
