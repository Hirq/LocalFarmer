using LocalFarmer.API.Enum;
using LocalFarmer.API.Utilities;
using LocalFarmer.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LocalFarmer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AuthenticationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUser, string role)
        {
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExist == null)
            {
                return StatusCode(StatusCodes.Status403Forbidden, new Response
                {
                    Status = StatusResponse.Error,
                    Message = "User already exixst!"
                });
            }

            var user = new ApplicationUser()
            {
                Email = registerUser.Email,
                UserName = registerUser.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var result = await _userManager.CreateAsync(user, registerUser.Password);

            return result.Succeeded
                ? StatusCode(StatusCodes.Status201Created, new Response
                {
                    Status = StatusResponse.Success,
                    Message = "User created successfully!"
                })
                : (IActionResult)StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = StatusResponse.Error,
                    Message = "User failed to create!"
                });
        }
    }
}
