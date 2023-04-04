using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class ProductsContext : DbContext
     {
          public ProductsContext() : base("name=EasyBreathDB")
          {

          }
          public virtual DbSet<Diet> Diets { get; set; }
     }
}
