using EasyBreath.Domain.Entities.User;
using System.Web;

namespace EasyBreath.web.Extensions
{
     public static class HttpContextExtensions
     {
          public static User GetMySessionObject(this HttpContext current)
          {
               return (User)current?.Session["__SessionObject"];
          }

          public static void SetMySessionObject(this HttpContext current, User profile)
          {
               current.Session.Add("__SessionObject", profile);
          }
     }
}