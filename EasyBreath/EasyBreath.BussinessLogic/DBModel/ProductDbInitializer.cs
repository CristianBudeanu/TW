using EasyBreath.Domain.Entities.Products;
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
     public class ProductDbInitializer
     {
          public static void Seed()
          {
               using (ProductsContext db = new ProductsContext())
               {
                    if (db.Database.Exists())
                    {
                         if (!db.Products.Any())
                         {
                              var products = new List<Product>
                              {
                                 new Product()
                                 {
                                      Name = "Vitamin C",
                                      Price = 35,
                                      Amount = 5,
                                      Thumbnail = "https://m.media-amazon.com/images/I/71GV-HLgI3L.jpg"
                                 },


                              new Product()
                              {
                                   Name = "Vitamin A",
                                      Price = 40,
                                      Amount = 5,
                                      Thumbnail = "https://m.media-amazon.com/images/I/71DttZDfFLL.jpg"
                              },


                              new Product()
                              {
                                   Name = "Vitamin B",
                                      Price = 45,
                                      Amount = 5,
                                      Thumbnail = "https://p9k6m7k4.rocketcdn.me/wp-content/uploads/2021/02/vitamin-B-complex.jpg"
                              },

                              new Product()
                              {
                                   Name = "Vitamin D",
                                      Price = 50,
                                      Amount = 5,
                                      Thumbnail = "https://m.media-amazon.com/images/I/71JO8SJ5mBL.jpg"
                              },
                              new Product()
                              {
                                   Name = "Vitamin E",
                                      Price = 35,
                                      Amount = 5,
                                      Thumbnail = "https://www.natr.md/wp-content/uploads/2022/05/1650-new.jpg"
                              },
                              new Product()
                              {
                                   Name = "Vitamin Omega-3",
                                      Price = 35,
                                      Amount = 5,
                                      Thumbnail = "https://biotus.md/media/catalog/product/cache/fa65709cb924250dcd7e95212b5f977b/s/o/solgar_omega-3_epa_dha_-100-25.jpg"
                              },
                              new Product()
                              {
                                   Name = "Calciu",
                                      Price = 35,
                                      Amount = 5,
                                      Thumbnail = "https://yarba.md/wp-content/uploads/2021/06/4e6b660769d711ea9da5480fcf36b953_ec71a3e169d811ea9da5480fcf36b953.jpg"
                              }

                         };
                              products.ForEach(p => db.Products.Add(p));
                              db.SaveChanges();
                         }
                    }

               }

          }
     }
}
