using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyBreath.web.Models
{
     public class Register
     {
          public int ID { get; set; }

          public string UserType { get; set; }

          public string FullName { get; set; }

          public string AdType { get; set; }

          public string UserName { get; set; }

          public string Email { get; set; }

          public string Password { get; set; }

          public string ConfirmPassword { get; set; }

          public List<Register> RegisterInfo { get; set; }
     }
}