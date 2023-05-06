using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;

namespace EasyBreath.BussinessLogic.Interfaces
{
     public interface ISession
     {
          ServiceResponse ValidateUserCredential(ULoginData user);
          ServiceResponse ValidateNewPassword(UChangePasswordData password);
          ServiceResponse ValidateUserRegister(URegisterData newUuser);
          CookieResponse GenCookie(string username);
          UserMinimal GetUserByCookie(string value);
          
          ServiceResponse ValidateEditUser(UDbModel user);
          ServiceResponse ValidateDeleteUser(UDbModel user);

     }
}
