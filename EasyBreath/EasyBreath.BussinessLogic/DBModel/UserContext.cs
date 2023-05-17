using EasyBreath.Domain.Entities.User;
using System.Data.Entity;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class UserContext : DbContext
     {
          public UserContext() : base("name=EasyBreathDB")
          {

          }
          public DbSet<User> Users { get; set; }
    }
}
