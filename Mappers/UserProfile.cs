using AutoMapper;
using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.ViewModels.User;

namespace DaldeApartmentAPI.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDetailViewModel>();
            CreateMap<User, UserDetailsViewModel>();
        }
    }
}
