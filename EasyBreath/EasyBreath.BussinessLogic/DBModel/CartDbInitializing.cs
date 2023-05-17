using EasyBreath.Domain.Entities.Carts;
using EasyBreath.Domain.Entities.Products;
using System.Collections.Generic;
using System.Linq;


namespace EasyBreath.BussinessLogic.DBModel
{
     public class CartDbInitializer
     {
          public static void Seed()
          {
               using (CartContext db = new CartContext())
               {
                    if (db.Database.CreateIfNotExists())
                    {
                         if (!db.Carts.Any())
                         {
                              var cart = new List<Cart>
                              {
                                 new Cart()
                                 {
                                      CartId = 999,
                                      ProductId = 999
                                 }

                         };
                              cart.ForEach(p => db.Carts.Add(p));
                              db.SaveChanges();
                         }
                    }

               }

          }
     }
}
