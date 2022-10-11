using DaldeApartmentAPI.Models;

namespace DaldeApartmentAPI.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<bool> CreatePaymentAsync(Payment paymentModel);
        Task<Payment> FetchPaymentDetailAsync(string paymentId);
        Task<IEnumerable<Payment>> FetchUserPaymentsAsync(string userId, int position);
        Task<bool> UpdatePaymentAsync(Payment paymentModel);
    }
}
