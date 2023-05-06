using EasyBreath.BussinessLogic.Core;
using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;

namespace EasyBreath.BussinessLogic
{
     public class SessionBL : UserApi, ISession
     {
          public ServiceResponse ValidateUserCredential(ULoginData user)
          {
               return ReturnCredentialStatus(user);
          }

          public ServiceResponse ValidateUserRegister(URegisterData user)
          {
               return ReturnRegisterStatus(user);
          }

          public ServiceResponse ValidateNewPassword(UChangePasswordData password)
          {
               return ReturnPasswordStatus(password);
          }

          public CookieResponse GenCookie(string username)
          {
               return CookieGeneratorAction(username);
          }

          public UserMinimal GetUserByCookie(string apiCookieValue)
          {
               return UserCookie(apiCookieValue);
          }
          public ServiceResponse ValidateEditUser(UDbModel data)
          {
               return ReturnEditUserStatus(data);
          }

          public ServiceResponse ValidateDeleteUser(UDbModel user)
          {
               return ReturnDeleteUserStatus(user);
          }


     }
}
