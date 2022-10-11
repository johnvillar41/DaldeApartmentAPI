using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaldeApartmentAPI.Repositories.Implementations
{
    public class RenterRepository : IRenterRepository
    {
        private readonly DaldeAptContext _context;
        public RenterRepository(DaldeAptContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(Renter entity)
        {
            await _context.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;

            return false;
        }

        public async Task<bool> DeleteAsync(Renter entity)
        {
            _context.Remove(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;

            return false;
        }

        public async Task<IEnumerable<Renter>> GetAllAsync()
        {
            return await _context.Renters.ToListAsync();
        }

        public Task<Renter> GetAsync(string id)
        {
            return _context.Renters.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Renter>> GetPaginatedAsync(int position)
        {
            return await _context.Renters
                .Skip(position)
                .Take(10)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Renter entity)
        {
            _context.Update(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;

            return false;
        }
    }
}
