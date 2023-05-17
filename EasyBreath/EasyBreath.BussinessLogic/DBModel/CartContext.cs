using EasyBreath.Domain.Entities.Carts;
using System.Data.Entity;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class CartContext : DbContext
     {
          public CartContext() : base("name=EasyBreathDB")
          {
               //Database.SetInitializer<CartContext>(null);
               EnsureDatabaseCreated();
          }

          public virtual DbSet<Cart> Carts { get; set; }
          public void EnsureDatabaseCreated()
          {
               if(!Database.Exists())
               {
                    Database.Create();
               }
          }
     }
}
