using EasyBreath.Domain.Entities.User;
using System.Data.Entity;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class UserContext : DbContext
     {
          public UserContext() : base("name=EasyBreath")
          {
               //Database.SetInitializer<UserContext>(new CreateDatabaseIfNotExists<UserContext>());
          }
          public DbSet<User> Users { get; set; }
     }
}
