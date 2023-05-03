//using EasyBreath.Domain.Entities.Products;
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
          public ProductsContext() : base("name=EasyBreath")
          {

          }
          //public virtual DbSet<Vitamin> Vitamins { get; set; }
     }
}
