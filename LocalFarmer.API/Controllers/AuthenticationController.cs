using LocalFarmer.API.Enum;
using LocalFarmer.API.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
                UserName = registerUser.Username,
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

        //TODO: DO poprawy
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDto loginUser)
        {
            try
            {
                String password = hashPassword(loginUser.Password);
                var user = _applicationUserRepository.GetAllAsync(x => x.UserName == loginUser.UserName && x.PasswordHash == password);

                if (user == null)
                {
                    return BadRequest("Username or password is incorrect");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private string hashPassword(string password)
        {
            var sha = SHA256.Create();
            var asByteArray = Encoding.Default.GetBytes(password);
            var hashedPassword = sha.ComputeHash(asByteArray);
            return Convert.ToBase64String(hashedPassword);
        }
    }
}
