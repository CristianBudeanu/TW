using EasyBreath.Domain.Entities.Carts;
using System.Data.Entity;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class CartContext : DbContext
     {
          public CartContext() : base("name=EasyBreathDB")
          {
          }

          public virtual DbSet<Cart> Carts { get; set; }
     }
}
