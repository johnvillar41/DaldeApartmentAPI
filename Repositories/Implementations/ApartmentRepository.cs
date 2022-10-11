using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaldeApartmentAPI.Repositories.Implementations
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly DaldeAptContext _context;
        public ApartmentRepository(DaldeAptContext context)
        {
            _context = context;
        }
        public async Task<bool> AddAsync(Apartment entity)
        {
            await _context.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;

            return false;
        }

        public async Task<bool> DeleteAsync(Apartment entity)
        {
            _context.Remove(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;

            return false;
        }

        public async Task<IEnumerable<Apartment>> GetAllAsync()
        {
            return await _context.Apartments.ToListAsync();
        }

        public async Task<Apartment> GetAsync(string id)
        {
            return await _context.Apartments.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Apartment>> GetPaginatedAsync(int position)
        {
            if (!await _context.Apartments.AnyAsync())
                return Enumerable.Empty<Apartment>();

            return await _context.Apartments
                .OrderBy(x => x.Id)
                .Skip(position)
                .Take(10)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Apartment entity)
        {
            _context.Update(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;

            return false;
        }
    }
}
