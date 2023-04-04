using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic.Interfaces
{
     public interface ISession
     {
          ServiceResponse ValidateUserCredential(ULoginData user);
          ServiceResponse ValidateNewPassword(UChangePasswordData password);
          //ServiceResponse ValidateUserRegister(URegisterData newUser);

     }
}
