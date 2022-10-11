using DaldeApartmentAPI.Models;

namespace DaldeApartmentAPI.Services.Interfaces
{
    public interface IApartmentService
    {
        Task<bool> CreateApartmentAsync(Apartment model);
        Task<bool> DeleteApartmentAsync(string apartmentId);
        Task<Apartment> FetchApartmentAsync(string apartmentId);
        Task<IEnumerable<Apartment>> FetchPaginatedApartmentsAsync(int position);
        Task<bool> UpdateApartmentAsync(Apartment model);
    }
}
