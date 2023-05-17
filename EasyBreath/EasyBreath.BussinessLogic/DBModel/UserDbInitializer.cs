using EasyBreath.Domain.Entities.User;
using EasyBreath.Domain.Enum;
using EasyBreath.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class UserDbInitializer
     {
          public static void Seed()
          {
               using (UserContext db = new UserContext())
               {
                    if (db.Database.Exists())
                    {
                         if (!db.Users.Any())
                         {

                              var users = new List<User>
                              {
                                 new User()
                                 {
                                      Username = "Cristian",
                                      Password = LoginHelper.HashGen("cristian123"),
                                      Email = "cristian.budeanu@isa.utm.md",
                                      RegisterDateTime = DateTime.UtcNow,
                                      AccessLevel = URole.ADMINISTRATOR
                                 },


                              new User()
                              {
                                   Username = "Ruxanda",
                                   Password = LoginHelper.HashGen("ruxanda123"),
                                   Email = "ruxanda559@gmail.com",
                                   LoginDateTime = DateTime.Now,
                                   RegisterDateTime = DateTime.UtcNow,
                                   AccessLevel = URole.ADMINISTRATOR
                              },


                              new User()
                              {
                                   Username = "Pepenel",
                                   Password = LoginHelper.HashGen("pepenel123"),
                                   Email = "pepenel@gmail.com",
                                   RegisterDateTime = DateTime.UtcNow,
                                   AccessLevel = URole.ADMINISTRATOR
                              },

                              new User()
                              {
                                   Username = "Alexandra",
                                   Password = LoginHelper.HashGen("alexandra123"),
                                   Email = "alexandra@gmail.com",
                                   RegisterDateTime = DateTime.UtcNow,
                                   AccessLevel = URole.ADMINISTRATOR
                              },


                              new User()
                              {
                                   Username = "test",
                                   Password = LoginHelper.HashGen("test123456"),
                                   Email = "test@gmail.com",
                                   RegisterDateTime = DateTime.UtcNow,
                                   AccessLevel = URole.USER
                              }
                         };
                              users.ForEach(p => db.Users.Add(p));
                              db.SaveChanges();
                         }
                    }

               }

          }
     }
}
