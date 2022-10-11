using DaldeApartmentAPI.Models;

namespace DaldeApartmentAPI.Services.Interfaces
{
    public interface IApartmentRenterService
    {
        Task<bool> CreateApartmentRenterAsync(ApartmentRenter model);
        Task<IEnumerable<ApartmentRenter>> FetchPaginatedApartmentRentersByIdAsync(string apartmentId, int position);
        Task<IEnumerable<ApartmentRenter>> FetchPaginatedApartmentRentersAsync(int position);
        Task<bool> UpdateApartmentRenterAsync(ApartmentRenter model);
        Task<bool> DeleteApartmentRenterAsync(string apartmentRenterId);
    }
}
