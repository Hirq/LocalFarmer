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

        public async Task AddUser(RegisterAccountForm registerUser, string role)
        {
            RegisterUserDto userDto = new RegisterUserDto()
            {
                Username = registerUser.Email,
                Email = registerUser.Email,
                Password = registerUser.Password,
            };

            await _http.PostAsJsonAsync($"https://localhost:7290/api/Authentication?role={role}", userDto);
        }

        //Trzeba dodać logowanie uzytkownika
    }
}
