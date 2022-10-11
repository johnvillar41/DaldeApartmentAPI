using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaldeApartmentAPI.Repositories.Implementations
{
    public class ApartmentRenterRepository : IApartmentRenterRepository
    {
        private readonly DaldeAptContext _context;

        public ApartmentRenterRepository(DaldeAptContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(ApartmentRenter entity)
        {
            await _context.ApartmentRenters.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;

            return false;
        }

        public async Task<bool> CheckIfApartmentRenterExist(string renterId)
        {
            var apartmentRenter = await _context.ApartmentRenters
                .FirstOrDefaultAsync(x => x.RenterId.Equals(renterId) && x.DateEnded != null);
            if (apartmentRenter == null)
                return false;

            return true;
        }

        public async Task<bool> DeleteAsync(ApartmentRenter entity)
        {
            _context.Remove(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;

            return false;
        }

        public async Task<IEnumerable<ApartmentRenter>> GetAllAsync()
        {
            return await _context.ApartmentRenters.ToListAsync();
        }

        public async Task<ApartmentRenter> GetAsync(string id)
        {
            return await _context.ApartmentRenters.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<ApartmentRenter>> GetPaginatedAsync(int position)
        {
            if (!await _context.ApartmentRenters.AnyAsync())
                return Enumerable.Empty<ApartmentRenter>();

            return await _context.ApartmentRenters
                .Skip(10)
                .OrderBy(x => x.Id)
                .Take(position)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(ApartmentRenter entity)
        {
            _context.Update(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;

            return false;
        }
    }
}
