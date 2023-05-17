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
                    if (db.Database.CreateIfNotExists())
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
