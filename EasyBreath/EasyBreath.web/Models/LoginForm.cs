using System.ComponentModel.DataAnnotations;

namespace EasyBreath.web.Models
{
     public class LoginForm
     {
          [Required(ErrorMessage = "You must enter your Username.")]
          public string Username { get; set; }

          [Required(ErrorMessage = "You must enter your password.")]
          public string Password { get; set; }
     }
}