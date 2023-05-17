using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.ShoppingCart;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class CartsContext : DbContext
     {
          public CartsContext() : base("name=EasyBreathDB") 
          {
               Database.SetInitializer(new CartsDbInitializer());
          }

          public virtual DbSet<ShoppingItemCart> Carts { get; set; }

          
     }
}
