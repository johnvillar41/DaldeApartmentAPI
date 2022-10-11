using AutoMapper;
using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.ViewModels.Apartment;

namespace DaldeApartmentAPI.Mappers
{
    public class ApartmentProfile : Profile
    {
        public ApartmentProfile()
        {
            CreateMap<ApartmentCreateOrUpdateViewModel, Apartment>();
            CreateMap<Apartment, ApartmentCreateOrUpdateViewModel>();
            CreateMap<Apartment, ApartmentDetailsViewModel>();
            CreateMap<Apartment, ApartmentDetailViewModel>();
        }
    }
}
