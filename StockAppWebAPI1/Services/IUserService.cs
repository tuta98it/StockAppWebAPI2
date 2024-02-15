using StockAppWebAPI1.Models;

namespace StockAppWebAPI1.Services
{
    public interface IUserService
    {
        Task<User> Register(User user);
    }
}
