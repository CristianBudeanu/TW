using EasyBreath.BussinessLogic.Core;
using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic
{
     public class SessionBL : UserApi, ISession
     {
          public ServiceResponse ValidateUserCredential(ULoginData user)
          {
               return ReturnCredentialStatus(user);
          }

          public ServiceResponse ValidateNewPassword(UChangePasswordData password)
          {
               return ReturnPasswordStatus(password);
          }

          //public ServiceResponse ValidateUserRegister(URegisterData newUser)
          //{
          //     return ReturnRegisterStatus(newUser);
          //}


     }
}
