using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.Repositories.Interfaces;
using DaldeApartmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaldeApartmentAPI.Services.Implementations
{
    public class RenterService : IRenterService
    {
        private readonly IRenterRepository _renterRepository;

        public RenterService(IRenterRepository renterRepository)
        {
            _renterRepository = renterRepository;
        }

        public async Task<bool> CreateRenterAsync(Renter model)
        {
            return await _renterRepository.AddAsync(model);
        }

        public async Task<IEnumerable<Renter>> FetchPaginatedRentersAsync(int position)
        {
            return await _renterRepository.GetPaginatedAsync(position);
        }

        public async Task<Renter> FetchRenterDetailsAsync(string renterId)
        {
            return await _renterRepository.GetAsync(renterId);
        }

        public async Task<bool> UpdateRenterAsync(Renter model)
        {
            return await _renterRepository.UpdateAsync(model);
        }
    }
}
