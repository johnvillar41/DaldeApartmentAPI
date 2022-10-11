using AutoMapper;
using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.ViewModels.ApartmentRenter;

namespace DaldeApartmentAPI.Mappers
{
    public class ApartmentRenterProfile : Profile
    {
        public ApartmentRenterProfile()
        {
            CreateMap<ApartmentRenterCreateOrUpdateViewModel, ApartmentRenter>();
        }
    }
}
