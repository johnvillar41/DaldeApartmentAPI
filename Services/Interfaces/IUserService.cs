using DaldeApartmentAPI.Models;

namespace DaldeApartmentAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> FetchUserAsync(string userId);
        Task<IEnumerable<User>> FetchUsersAsync(int position);
        Task<bool> CreateUserAsync(User user);
    }
}
