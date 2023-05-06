using EasyBreath.Domain.Entities.User;
using System.Web;

namespace EasyBreath.web.Extensions
{
     public static class HttpContextExtensions
     {
          public static UserMinimal GetMySessionObject(this HttpContext current)
          {
               return (UserMinimal)current?.Session["__SessionObject"];

          }

          public static void SetMySessionObject(this HttpContext current, UserMinimal profile)
          {
               current.Session.Add("__SessionObject", profile);
          }
     }
}