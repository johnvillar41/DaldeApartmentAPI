using AutoMapper;
using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.ViewModels.Payment;

namespace DaldeApartmentAPI.Mappers
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<PaymentCreateOrUpdateViewModel, Payment>()
                .ForMember(x => x.RenterId, opt => opt.MapFrom(src => src.WhoRentedId));
            CreateMap<Payment, PaymentDetailsViewModel>();
        }
    }
}
