using AutoMapper;
using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.Services.Interfaces;
using DaldeApartmentAPI.ViewModels.Payment;
using Microsoft.AspNetCore.Mvc;

namespace DaldeApartmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<PaymentController> _logger;
        public PaymentController(
            IPaymentService service,
            IMapper mapper,
            ILogger<PaymentController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Payment([FromBody] PaymentCreateOrUpdateViewModel payment)
        {
            try
            {
                var paymentModel = _mapper.Map<PaymentCreateOrUpdateViewModel, Payment>(payment);
                if (payment.Id == null)
                {
                    var result = await _service.CreatePaymentAsync(paymentModel);
                    if (result)
                        return CreatedAtAction(nameof(Payment), paymentModel);
                }
                else
                {
                    paymentModel.Id = Guid.NewGuid().ToString();
                    var result = await _service.UpdatePaymentAsync(paymentModel);
                    if (result)
                        return CreatedAtAction(nameof(Payment), paymentModel);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating payment");
                return BadRequest("Error creating payment");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Payment([FromQuery] string paymentId)
        {
            try
            {
                var payment = await _service.FetchPaymentDetailAsync(paymentId);
                if (payment == null)
                    return NotFound($"No Payment found for id: {paymentId}");

                var paymentViewModel = _mapper.Map<Payment, PaymentDetailViewModel>(payment);
                return Ok(paymentViewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Displaying payment detail error");
                return BadRequest();
            }
        }

        [HttpGet("Payments")]
        public async Task<IActionResult> Payments([FromQuery] string userId, [FromQuery] int pageNumber)
        {
            try
            {
                var position = pageNumber * 10;
                var payments = await _service.FetchUserPaymentsAsync(userId, position);
                var viewModels = _mapper.Map<IEnumerable<PaymentDetailsViewModel>>(payments);
                return Ok(viewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error has occured");
                return BadRequest();
            }
        }
    }
}
