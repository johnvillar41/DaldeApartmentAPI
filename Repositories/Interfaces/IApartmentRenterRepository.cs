using DaldeApartmentAPI.Models;

namespace DaldeApartmentAPI.Repositories.Interfaces
{
    public interface IApartmentRenterRepository : IGenericRepository<ApartmentRenter>
    {
        Task<bool> CheckIfApartmentRenterExist(string renterId);
    }
}
