//using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.Products;
using System.Data.Entity;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class ProductsContext : DbContext
     {
          public ProductsContext() : base("name=EasyBreathDB")
          {

          }
          public virtual DbSet<Product> Products { get; set; }
     }
}
