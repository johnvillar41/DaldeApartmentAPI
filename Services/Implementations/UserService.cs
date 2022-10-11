using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaldeApartmentAPI.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DaldeAptContext _context;
        public UserService(DaldeAptContext context)
        {
            _context = context;
        }
        public async Task<bool> CreateUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            var result = await _context.SaveChangesAsync();
            if (result > 0)
                return true;

            return false;
        }

        public async Task<User> FetchUserAsync(string userId)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(userId));
        }

        public async Task<IEnumerable<User>> FetchUsersAsync(int position)
        {
            throw new NotImplementedException();
        }
    }
}
