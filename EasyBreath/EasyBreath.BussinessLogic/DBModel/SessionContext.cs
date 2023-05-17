using EasyBreath.Domain.Entities;
using System.Data.Entity;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class SessionContext : DbContext
     {
          public SessionContext() : base("name=EasyBreathDB") { }

          public virtual DbSet<SDbModel> Sessions { get; set; }
     }
}
