using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaldeApartmentAPI.Repositories.Implementations
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly DaldeAptContext _context;
        public PaymentRepository(DaldeAptContext daldeAptContext)
        {
            _context = daldeAptContext;
        }
        public async Task<bool> AddAsync(Payment entity)
        {
            await _context.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;

            return false;
        }

        public async Task<bool> DeleteAsync(Payment entity)
        {
            _context.Remove(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;

            return false;
        }

        public async Task<IEnumerable<Payment>> GetAllAsync()
        {
            return await _context.Payments.ToListAsync();
        }

        public async Task<Payment> GetAsync(string id)
        {
            return await _context.Payments.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task<IEnumerable<Payment>> GetPaginatedAsync(int position)
        {
            return await _context.Payments
                .Take(10)
                .Skip(position)
                .ToListAsync();
        }

        public async Task<IEnumerable<Payment>> GetPaginatedPaymentForRenterAsync(string renterId, int position)
        {
            return await _context.Payments
                .Where(x => x.RenterId.Equals(renterId))
                .Take(10)
                .Skip(position)
                .OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<bool> UpdateAsync(Payment entity)
        {
            _context.Update(entity);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;

            return false;
        }
    }
}
