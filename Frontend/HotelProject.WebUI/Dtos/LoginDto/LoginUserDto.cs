using System.ComponentModel.DataAnnotations;

namespace HotelProject.WebUI.Dtos.LoginDto
{
    public class LoginUserDto
    {
        [Required(ErrorMessage = "kullanıcı adını giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "kullanıcı adını giriniz")]
        public string Password { get; set; }
    }
}
