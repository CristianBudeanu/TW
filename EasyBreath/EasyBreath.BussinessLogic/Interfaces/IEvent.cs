using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic.Interfaces
{
     public interface IEvent
     {
          Events GetEventById(int id);
          List<Events> GetEventList();
          ServiceResponse ValidateEditEvent(Events events);
          ServiceResponse ValidateDeleteEvent(Events events);
          ServiceResponse ValidateCreateEvent(Events events);
     }
}
