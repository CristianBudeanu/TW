using EasyBreath.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
