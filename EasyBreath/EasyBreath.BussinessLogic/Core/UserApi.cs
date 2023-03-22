using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic.Core
{
     public class UserApi
     {
          public ServiceResponse ReturnCredentialStatus(ULoginData user)
          {
               return new ServiceResponse { Status = true, StatusMessage = string.Empty };
          }
          public CookieResponse ReturnSessionCookie(UCookieData utoken)
          {
               return new CookieResponse { Data = DateTime.Now, Cookie = "123" };
          }

          public ServiceResponse ReturnPasswordStatus(UChangePasswordData password)
          {
               return new ServiceResponse { Status = true, StatusMessage = "Password has been changed succesfully!" };
          }
     }
}
