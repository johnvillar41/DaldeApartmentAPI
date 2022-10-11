using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.Repositories.Interfaces;
using DaldeApartmentAPI.Services.Interfaces;

namespace DaldeApartmentAPI.Services.Implementations
{
    public class ApartmentService : IApartmentService
    {
        private readonly IApartmentRepository _apartmentRepository;

        public ApartmentService(IApartmentRepository apartmentRepository)
        {
            _apartmentRepository = apartmentRepository;
        }

        public async Task<bool> CreateApartmentAsync(Apartment model)
        {
            return await _apartmentRepository.AddAsync(model);
        }

        public async Task<bool> DeleteApartmentAsync(string apartmentId)
        {
            return await _apartmentRepository.DeleteAsync(new Apartment() { Id = apartmentId });
        }

        public async Task<Apartment> FetchApartmentAsync(string apartmentId)
        {
            return await _apartmentRepository.GetAsync(apartmentId);
        }

        public async Task<IEnumerable<Apartment>> FetchPaginatedApartmentsAsync(int position)
        {
            return await _apartmentRepository.GetPaginatedAsync(position);
        }

        public async Task<bool> UpdateApartmentAsync(Apartment model)
        {
            return await _apartmentRepository.UpdateAsync(model);
        }
    }
}
