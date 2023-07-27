using LocalFarmer.API.Enum;
using LocalFarmer.API.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace LocalFarmer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IApplicationUserRepository _applicationUserRepository;

        public AuthenticationController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration,
            IApplicationUserRepository applicationUserRepository)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _applicationUserRepository = applicationUserRepository;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDto registerUser, string role)
        {
            var userExist = await _userManager.FindByEmailAsync(registerUser.Email);
            if (userExist != null)
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
                UserName = registerUser.UserName,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            if (await _roleManager.RoleExistsAsync(role))
            {
                var result = await _userManager.CreateAsync(user, registerUser.Password);
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, new Response
                    {
                        Status = StatusResponse.Error,
                        Message = "User failed to create!"
                    });
                }
                //Add role to user

                await _userManager.AddToRoleAsync(user, role);
                return StatusCode(StatusCodes.Status201Created, new Response
                {
                    Status = StatusResponse.Success,
                    Message = "User created successfully!"
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                {
                    Status = StatusResponse.Error,
                    Message = "This role doesn't exist!"
                });
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUser)
        {
            var userExist = await _userManager.FindByNameAsync(loginUser.UserName);

            if (userExist == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response
                {
                    Status = StatusResponse.Error,
                    Message = "User not exixst!"
                });
            }
            
            if (!await _userManager.CheckPasswordAsync(userExist, loginUser.Password))
            {
                return StatusCode(StatusCodes.Status404NotFound, new Response
                {
                    Status = StatusResponse.Error,
                    Message = "Password incorrect!"
                });
            }
            else
            {
                var result = await _signInManager.PasswordSignInAsync(loginUser.UserName, loginUser.Password, false, false);

                if (result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status200OK, new Response
                    {
                        Status = StatusResponse.Success,
                        Message = "User logged!"
                    });
                }
                else
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new Response
                    {
                        Status = StatusResponse.Error,
                        Message = "Bad request!"
                    });
                }

            }
        }

    }
}
