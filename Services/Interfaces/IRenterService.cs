using DaldeApartmentAPI.Models;

namespace DaldeApartmentAPI.Services.Interfaces
{
    public interface IRenterService
    {
        Task<Renter> FetchRenterDetailsAsync(string renterId);
        Task<IEnumerable<Renter>> FetchPaginatedRentersAsync(int position);
        Task<bool> CreateRenterAsync(Renter model);
        Task<bool> UpdateRenterAsync(Renter model);
    }
}
