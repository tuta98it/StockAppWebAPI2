using StockAppWebAPI1.Models;

namespace StockAppWebAPI1.Repository
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<User> GetById(int id);
        Task<User> GetByUsername(string username);
        Task<User> GetByEmail(string email);
        Task<User> UpdateById(int id, User user);
        Task DeleteById(int id);
    }
}
