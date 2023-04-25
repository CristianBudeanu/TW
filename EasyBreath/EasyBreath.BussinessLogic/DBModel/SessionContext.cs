using EasyBreath.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class SessionContext : DbContext
     {
          public SessionContext() : base("name=EasyBreathDB") { }

          public virtual DbSet<SDbModel> Sessions { get; set; }
     }
}
