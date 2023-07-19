using System.ComponentModel.DataAnnotations;

namespace LocalFarmer.Domain.ViewModels.DTOs
{
    public class LoginUserDto
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
