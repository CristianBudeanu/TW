using System;
using System.Collections.Generic;
using EasyBreath.Domain.Entities.Event;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class EventsContext : DbContext
     {
          public EventsContext() : base("name=EasyBreathDB")
          {

          }
          public virtual DbSet<Events> Events { get; set; }
     }
}
