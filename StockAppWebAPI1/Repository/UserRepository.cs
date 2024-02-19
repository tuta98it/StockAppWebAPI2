using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using StockAppWebAPI1.Models;
using StockAppWebAPI1.ViewModels;

namespace StockAppWebAPI1.Repository
{

    public class UserRepository : IUserRepository
    {
        private readonly StockAppContext _context;
        public UserRepository(StockAppContext context)
        {
            _context = context;
        }

        public async Task<User?> Create(RegisterViewModel registerViewModel)
        {
            //Đoạn này sẽ gọi 1 procedure trong SQL
            string sql = "EXECUTE dbo.RegisterUser @username, " +
                            "@password, " +
                            "@email, " +
                            "@phone, " +
                            "@full_name, " +
                            "@date_of_birth, " +
                            "@country";
            IEnumerable<User> result = await _context.Users.FromSqlRaw(sql,
                        new SqlParameter("@username", registerViewModel.Username ?? ""),
                        new SqlParameter("@password", registerViewModel.Password),
                        new SqlParameter("@email", registerViewModel.Email),
                        new SqlParameter("@phone", registerViewModel.Phone ?? ""),
                        new SqlParameter("@full_name", registerViewModel.FullName ?? ""),
                        new SqlParameter("@date_of_birth", registerViewModel.DateOfBirth),
                        new SqlParameter("@country", registerViewModel.Country)).ToListAsync();

            User? user = result.FirstOrDefault();
            return user;
        }


        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?> GetById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<User?> UpdateById(int id, User user)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found");
            }
            var properties = typeof(User).GetProperties();
            foreach (var property in properties)
            {
                var newValue = property.GetValue(user);
                if (newValue != null)
                {
                    property.SetValue(existingUser, newValue);
                }
            }
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<User?> DeleteById(int id)
        {
            var existingUser = await _context.Users.FindAsync(id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found");
            }
            _context.Remove(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }
    }
}
