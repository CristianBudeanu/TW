using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;
using static EasyBreath.BussinessLogic.Core.ProductApi;
using static EasyBreath.BussinessLogic.Core.SessionApi;

namespace EasyBreath.BussinessLogic.Interfaces
{
     public interface ISession
     {
          ServiceResponse ValidateUserCredential(LoginData user);
          ServiceResponse ValidateUserRegister(RegisterData newUuser);
          CookieResponse GenCookie(string username);
          User GetUserByCookie(string value);
     }
}
