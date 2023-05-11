using System;

namespace EasyBreath.Domain.Entities.User
{
     public class URegisterData
     {
          public string Username { get; set; }
          public string Password { get; set; }
          public string Email { get; set; }
          public DateTime RegisterDateTime { get; set; }
     }
}
