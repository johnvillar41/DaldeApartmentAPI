using DaldeApartmentAPI.Models;

namespace DaldeApartmentAPI.Repositories.Interfaces
{
    public interface IPaymentRepository : IGenericRepository<Payment>
    {
        Task<IEnumerable<Payment>> GetPaginatedPaymentForRenterAsync(string renterId, int position);
    }
}
