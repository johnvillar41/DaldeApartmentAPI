using AutoMapper;
using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.Services.Interfaces;
using DaldeApartmentAPI.ViewModels.Apartment;
using Microsoft.AspNetCore.Mvc;

namespace DaldeApartmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<ApartmentController> _logger;
        public ApartmentController(IApartmentService service, IMapper mapper, ILogger<ApartmentController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Apartment([FromQuery] string apartmentId)
        {
            try
            {
                var apartment = await _service.FetchApartmentAsync(apartmentId);
                if (apartment == null)
                    return NotFound();

                var viewModel = _mapper.Map<ApartmentDetailViewModel>(apartment);
                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error finding apartment");
                return BadRequest("Error finding apartment");
            }
        }

        [HttpGet("Apartments")]
        public async Task<IActionResult> Apartments([FromQuery] int pageNumber)
        {
            try
            {
                var position = pageNumber * 10;
                var apartments = await _service.FetchPaginatedApartmentsAsync(position);
                if (!apartments.Any())
                    return new NoContentResult();

                var viewModels = _mapper.Map<IEnumerable<ApartmentDetailsViewModel>>(apartments);
                return Ok(viewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching apartments");
                return BadRequest("Error fetching apartments");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Apartment([FromBody] ApartmentCreateOrUpdateViewModel apartment)
        {
            try
            {
                var model = _mapper.Map<Apartment>(apartment);
                if (apartment.Id == null)
                {
                    model.Id = Guid.NewGuid().ToString();
                    var result = await _service.CreateApartmentAsync(model);
                    if (result)
                        return CreatedAtAction(nameof(Apartment), _mapper.Map<ApartmentCreateOrUpdateViewModel>(model));
                }
                else
                {
                    var result = await _service.UpdateApartmentAsync(model);
                    if (result)
                        return CreatedAtAction(nameof(Apartment), _mapper.Map<ApartmentCreateOrUpdateViewModel>(model));
                }
                return BadRequest();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating apartmrnt");
                return BadRequest("Error creating apartmrnt");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApartment([FromQuery] string apartmentId)
        {
            try
            {
                var result = await _service.DeleteApartmentAsync(apartmentId);
                if (result)
                    return Ok(result);

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting apartmrnt");
                return BadRequest("Error deleting apartmrnt");
            }
        }
    }
}
