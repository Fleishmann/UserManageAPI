using LoremIpsumLogistica.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using UserManageAPI.Data;

namespace UserManageAPI.Services
{
    public class AddressService
    {
        private readonly ApplicationDbContext _context;

        public AddressService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Address>> GetAllAddressesAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task<IEnumerable<Address>> GetAddressesByUserIdAsync(int userId)
        {
            return await _context.Addresses
                                 .Where(a => a.UserId == userId)
                                 .ToListAsync();
        }

        public async Task<Address> AddAddressAsync(Address address)
        {
            var user = await _context.Users.FindAsync(address.UserId);

            if (user == null)
            {
                throw new ArgumentException($"Usuário com ID {address.UserId} não encontrado.");
            }

            if (user.Addresses == null)
            {
                user.Addresses = new List<Address>();
            }

            user.Addresses.Add(address);

            await _context.SaveChangesAsync();

            return address;
        }

        public async Task<Address> UpdateAddressAsync(Address address)
        {
            _context.Entry(address).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return address;
        }

        public async Task<bool> DeleteAddressAsync(int id)
        {
            var address = await _context.Addresses.FindAsync(id);
            if (address == null)
            {
                return false;
            }

            _context.Addresses.Remove(address);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Address> GetAddressByIdAsync(int id)
        {
            return await _context.Addresses.FindAsync(id);
        }
    }
}