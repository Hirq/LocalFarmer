using static LocalFarmer.Web.Pages.Account.Login;
using static LocalFarmer.Web.Pages.Account.Register;

namespace LocalFarmer.Web.Services
{
    public interface IUserService
    {
        public Task RegisterUser(RegisterAccountForm registerUser);
        public Task LoginUser(LoginAccountForm registerUser);
    }
}
