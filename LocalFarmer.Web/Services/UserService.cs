using LocalFarmer.Domain.Const;
using static LocalFarmer.Web.Pages.Account.Login;
using static LocalFarmer.Web.Pages.Account.Register;

namespace LocalFarmer.Web.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _http;

        public UserService(HttpClient http)
        {
            _http = http;
        }

        public async Task RegisterUser(RegisterAccountForm registerUser)
        {
            string role = RolesUser.User;
            RegisterUserDto userDto = new RegisterUserDto()
            {
                UserName = registerUser.Email,
                Email = registerUser.Email,
                Password = registerUser.Password,
            };

            await _http.PostAsJsonAsync($"https://localhost:7290/api/Authentication?role={role}", userDto);
        }      
        
        public async Task LoginUser(LoginAccountForm registerUser)
        {
            LoginUserDto userDto = new LoginUserDto()
            {
                UserName = registerUser.Email,
                Password = registerUser.Password,
            };

            await _http.PostAsJsonAsync($"https://localhost:7290/api/Authentication/Login", userDto);
        }
    }
}
