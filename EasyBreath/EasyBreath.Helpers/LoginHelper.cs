using System;
using System.Security.Cryptography;
using System.Text;

namespace EasyBreath.Helpers
{
     public class LoginHelper
     {
          public static string HashGen(string password)
          {
               MD5 md5 = new MD5CryptoServiceProvider();
               var originalBytes = Encoding.Default.GetBytes(password + "twutm2023");
               var encodedBytes = md5.ComputeHash(originalBytes);

               return BitConverter.ToString(encodedBytes).Replace("-", "").ToLower();
          }
     }
}
