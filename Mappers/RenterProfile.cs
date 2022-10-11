using AutoMapper;
using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.ViewModels.Renter;

namespace DaldeApartmentAPI.Mappers
{
    public class RenterProfile : Profile
    {
        public RenterProfile()
        {
            CreateMap<Renter, RenterDetailViewModel>();
            CreateMap<RenterCreateOrUpdateViewModel, Renter>();
            CreateMap<Renter, RenterDetailsViewModel>();
        }
    }
}
