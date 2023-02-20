using Microsoft.EntityFrameworkCore;
using Services.Models;
using Services.Models.ViewModels;

namespace Services
{
    public class AddressService
    {
        private readonly AppDbContext _context;

        public AddressService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Address> DetailsAsync(int? id)
        {
            if (id == null || _context.Addresses == null)
            {
                return null;
            }

            var address = await _context.Addresses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (address == null)
            {
                return null;
            }
            return address;
        }

        public async Task<IEnumerable<Address>> IndexAsync()
        {
            return await _context.Addresses.ToListAsync();
        }

        public async Task CreateAsync(AddressViewModel address)
        {
            _context.Add(address);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(AddressViewModel address)
        {
            _context.Update(address);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? id)
        {
            _context.Remove(id);
            await _context.SaveChangesAsync();
        }
    }
}
