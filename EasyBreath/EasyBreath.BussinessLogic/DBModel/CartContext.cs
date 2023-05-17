using EasyBreath.Domain.Entities.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class CartContext : DbContext
     {
          public CartContext() : base("name=EasyBreath")
          {

          }

          public virtual DbSet<Cart> Carts { get; set; }
     }
}
