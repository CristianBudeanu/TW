using EasyBreath.BussinessLogic.Core;
using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;
using static EasyBreath.BussinessLogic.Core.SessionApi;

namespace EasyBreath.BussinessLogic
{
     public class SessionBL : SessionApi, ISession
     {

          public ServiceResponse ValidateUserCredential(LoginData user)
          {
               return ReturnCredentialStatus(user);        
          }

          public ServiceResponse ValidateUserRegister(RegisterData user)
          {
               return ReturnRegisterStatus(user);
          }

          public CookieResponse GenCookie(string username)
          {
               return CookieGeneratorAction(username);
          }

          public User GetUserByCookie(string apiCookieValue)
          {
               return UserCookie(apiCookieValue);
          }
     }
}
