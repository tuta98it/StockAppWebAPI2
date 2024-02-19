using StockAppWebAPI1.Models;
using StockAppWebAPI1.ViewModels;

namespace StockAppWebAPI1.Services
{
    public interface IUserService
    {
        Task<User?> Register(RegisterViewModel registerViewModel);
        Task<User?> GetByEmail(string email);
    }
}
