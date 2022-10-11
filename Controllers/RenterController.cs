using AutoMapper;
using DaldeApartmentAPI.Models;
using DaldeApartmentAPI.Services.Interfaces;
using DaldeApartmentAPI.ViewModels.Renter;
using Microsoft.AspNetCore.Mvc;

namespace DaldeApartmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RenterController : ControllerBase
    {
        private readonly IRenterService _service;
        private readonly IMapper _mapper;
        private readonly ILogger<RenterController> _logger;
        public RenterController(IRenterService service, IMapper mapper, ILogger<RenterController> logger)
        {
            _service = service;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Renter([FromQuery] string renterId)
        {
            try
            {
                var renter = await _service.FetchRenterDetailsAsync(renterId);
                if (renter == null)
                    return NotFound($"No renter found with id: {renterId}");

                var viewModel = _mapper.Map<RenterDetailViewModel>(renter);
                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching renter details");
                return BadRequest("Error fetching renter details");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Renter([FromBody] RenterCreateOrUpdateViewModel renter)
        {
            try
            {
                var model = _mapper.Map<Renter>(renter);
                if(renter.Id == null)
                {
                    var result = await _service.CreateRenterAsync(model);
                    if (result)
                        return CreatedAtAction(nameof(Renter), $"Successfully created renter: {renter.Id}");
                }
                else
                {
                    model.Id = Guid.NewGuid().ToString();
                    var result = await _service.UpdateRenterAsync(model);
                    if (result)
                        return CreatedAtAction(nameof(Renter), $"Successfully created renter: {renter.Id}");
                }
                

                return BadRequest($"Error creating renter: {renter.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating renter");
                return BadRequest("Error creating renter");
            }
        }

        [HttpGet("Renters")]
        public async Task<IActionResult> Renters([FromQuery] int pageNumber)
        {
            try
            {
                var position = pageNumber * 10;
                var renters = await _service.FetchPaginatedRentersAsync(position);
                if (!renters.Any())
                    return new NoContentResult();

                var viewModels = _mapper.Map<IEnumerable<RenterDetailsViewModel>>(renters);
                return Ok(viewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching renter");
                return BadRequest("Error fetching renter");
            }
        }
    }
}
