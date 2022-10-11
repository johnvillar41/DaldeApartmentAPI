using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.Repositories.Interfaces;
using DaldeApartmentAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DaldeApartmentAPI.Services.Implementations
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }

        public async Task<bool> CreatePaymentAsync(Payment paymentModel)
        {
            return await _paymentRepository.AddAsync(paymentModel);
        }

        public async Task<Payment> FetchPaymentDetailAsync(string paymentId)
        {
            return await _paymentRepository.GetAsync(paymentId);
        }

        public async Task<IEnumerable<Payment>> FetchUserPaymentsAsync(string userId, int position)
        {
            return await _paymentRepository.GetPaginatedPaymentForRenterAsync(userId, position);
        }

        public async Task<bool> UpdatePaymentAsync(Payment paymentModel)
        {
            return await _paymentRepository.UpdateAsync(paymentModel);
        }
    }
}
