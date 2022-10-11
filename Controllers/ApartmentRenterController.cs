using AutoMapper;
using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.Services.Interfaces;
using DaldeApartmentAPI.ViewModels.ApartmentRenter;
using Microsoft.AspNetCore.Mvc;

namespace DaldeApartmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApartmentRenterController : ControllerBase
    {
        private readonly IApartmentRenterService _service;
        private readonly ILogger<ApartmentRenterController> _logger;
        private readonly IMapper _mapper;
        public ApartmentRenterController(IApartmentRenterService service, ILogger<ApartmentRenterController> logger, IMapper mapper)
        {
            _service = service;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet("ApartmentRenters")]
        public async Task<IActionResult> ApartmentRenters([FromQuery] string? apartmentId, [FromQuery] int pageNumber)
        {
            try
            {
                var position = pageNumber * 10;
                IEnumerable<ApartmentRenter> apartmentRenters = null;
                if (apartmentId == null)
                {
                    apartmentRenters = await _service.FetchPaginatedApartmentRentersAsync(position);
                    if (!apartmentRenters.Any())
                        return NoContent();
                }
                else
                {
                    apartmentRenters = await _service.FetchPaginatedApartmentRentersByIdAsync(apartmentId, position);
                    if (!apartmentRenters.Any())
                        return NoContent();
                }
                var viewModels = _mapper.Map<IEnumerable<ApartmentRenterDetailsViewModel>>(apartmentRenters);
                return Ok(viewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching apartment renters");
                return BadRequest("Error fetching apartment renters");
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteApartmentRenter([FromQuery] string apartmentRenterId)
        {
            try
            {
                var result = await _service.DeleteApartmentRenterAsync(apartmentRenterId);
                if (result)
                    return Ok(result);

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting apartment renters");
                return BadRequest("Error deleting apartment renters");
            }
        }

        [HttpPost]
        public async Task<IActionResult> ApartmentRenter([FromBody] ApartmentRenterCreateOrUpdateViewModel apartment)
        {
            try
            {
                var model = _mapper.Map<ApartmentRenter>(apartment);
                if (apartment.Id == null)
                {
                    model.Id = Guid.NewGuid().ToString();
                    var result = await _service.CreateApartmentRenterAsync(model);
                    if (result)
                        return CreatedAtAction(nameof(ApartmentRenter), model);
                }
                else
                {
                    var result = await _service.UpdateApartmentRenterAsync(model);
                    if (result)
                        return CreatedAtAction(nameof(ApartmentRenter), model);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating apartment renter");
                return BadRequest("Error creating apartment renter");
            }
        }
    }
}
