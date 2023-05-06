//using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.Products;
using System.Data.Entity;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class ProductsContext : DbContext
     {
          public ProductsContext() : base("name=EasyBreath")
          {

          }
          public virtual DbSet<Product> Vitamins { get; set; }
     }
}
