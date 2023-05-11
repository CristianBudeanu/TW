using EasyBreath.Domain.Enum;
using System;

namespace EasyBreath.Domain.Entities.User
{
     public class UserMinimal
     {
          public int Id { get; set; }
          public string Username { get; set; }
          public string Email { get; set; }
          public DateTime LastLogin { get; set; }
          public URole Level { get; set; }

     }
}
