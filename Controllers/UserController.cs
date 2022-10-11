using AutoMapper;
using DaldeApartmentAPI.Services.Interfaces;
using DaldeApartmentAPI.ViewModels.User;
using Microsoft.AspNetCore.Mvc;

namespace DaldeApartmentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _service;

        public UserController(ILogger<UserController> logger, IMapper mapper, IUserService userService)
        {
            _logger = logger;
            _mapper = mapper;
            _service = userService;
        }

        [HttpGet]
        public async Task<IActionResult> User([FromQuery] string userId)
        {
            try
            {
                var user = await _service.FetchUserAsync(userId);
                if (user == null)
                    return NotFound("No user found");

                var viewModel = _mapper.Map<UserDetailViewModel>(user);
                return Ok(viewModel);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching user detail");
                return BadRequest("Error fetching user detail");
            }
        }

        [HttpGet("Users")]
        public async Task<IActionResult> Users([FromQuery] int pageNumber)
        {
            try
            {
                var position = pageNumber * 10;
                var users = await _service.FetchUsersAsync(position);
                if (!users.Any())
                    return new NoContentResult();

                var viewModels = _mapper.Map<IEnumerable<UserDetailsViewModel>>(users);
                return Ok(viewModels);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching users");
                return BadRequest("Error fetching users");
            }
        }
    }
}
