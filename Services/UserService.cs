using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageAPI.Data;
using UserManageAPI.Models;

namespace UserManageAPI.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users
                                 .Include(u => u.Addresses)
                                 .ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users
                                 .Include(u => u.Addresses)
                                 .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> AddUserAsync(User user)
        {
            var emailExists = await _context.Users.AnyAsync(u => u.Email == user.Email);
            if (emailExists)
            {
                throw new Exception("Email já em uso.");
            }

            if (!IsPasswordSecure(user.Password))
            {
                throw new Exception("A senha não é segura o suficiente.");
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            if (user.Addresses != null && user.Addresses.Count > 0)
            {
                foreach (var address in user.Addresses)
                {
                    _context.Addresses.Add(address);
                }
            }

            _context.Users.Add(user);

            await _context.SaveChangesAsync();

            return user;
        }

        private bool IsPasswordSecure(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }

            if (!password.Any(char.IsDigit) || !password.Any(char.IsLetter) || !password.Any(char.IsUpper))
            {
                return false;
            }

            return true;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            var existingUser = await _context.Users.FindAsync(user.Id);
            if (existingUser == null) return null;

            existingUser.Nome = user.Nome;
            existingUser.Email = user.Email;
            existingUser.DataNascimento = user.DataNascimento;
            existingUser.Sexo = user.Sexo;

            if (!string.IsNullOrWhiteSpace(user.Password))
            {
                existingUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            }

            _context.Users.Update(existingUser);
            await _context.SaveChangesAsync();
            return existingUser;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return false;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public User ValidateUser(UserLogin userLogin)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == userLogin.Email);
            if (user != null && BCrypt.Net.BCrypt.Verify(userLogin.Password, user.Password))
            {
                return user;
            }
            return null;
        }
    }
}