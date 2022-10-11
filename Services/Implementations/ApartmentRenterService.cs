using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.Repositories.Interfaces;
using DaldeApartmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaldeApartmentAPI.Services.Implementations
{
    public class ApartmentRenterService : IApartmentRenterService
    {
        private readonly IApartmentRenterRepository _apartmentRenterRepository;

        public ApartmentRenterService(IApartmentRenterRepository apartmentRenterRepository)
        {
            _apartmentRenterRepository = apartmentRenterRepository;
        }

        public async Task<bool> CreateApartmentRenterAsync(ApartmentRenter model)
        {
            var apartmentRenterExist = await _apartmentRenterRepository.CheckIfApartmentRenterExist(model.Id);
            if (apartmentRenterExist)
                return await _apartmentRenterRepository.AddAsync(model);

            return false;
        }

        public async Task<bool> DeleteApartmentRenterAsync(string apartmentRenterId)
        {
            return await _apartmentRenterRepository.DeleteAsync(new ApartmentRenter() { Id = apartmentRenterId });
        }

        public async Task<IEnumerable<ApartmentRenter>> FetchPaginatedApartmentRentersAsync(int position)
        {
            return await _apartmentRenterRepository.GetPaginatedAsync(position);
        }

        public async Task<IEnumerable<ApartmentRenter>> FetchPaginatedApartmentRentersByIdAsync(string apartmentId, int position)
        {
            return await _apartmentRenterRepository.GetPaginatedAsync(position);
        }

        public async Task<bool> UpdateApartmentRenterAsync(ApartmentRenter model)
        {
            return await _apartmentRenterRepository.UpdateAsync(model);
        }
    }
}
