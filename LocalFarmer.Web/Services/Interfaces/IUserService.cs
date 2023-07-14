using static LocalFarmer.Web.Pages.Account.Register;

namespace LocalFarmer.Web.Services
{
    public interface IUserService
    {
        public Task AddUser(RegisterAccountForm registerUser, string role);
    }
}
