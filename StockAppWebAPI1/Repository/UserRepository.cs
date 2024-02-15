using StockAppWebAPI1.Models;

namespace StockAppWebAPI1.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly StockAppContext _context;
        public UserRepository(StockAppContext context)
        {
            _context = context;
        }

        public Task<User> Create(User user)
        {
            return null;
        }

        public Task DeleteById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public Task<User> UpdateById(int id, User user)
        {
            throw new NotImplementedException();
        }
    }
}
