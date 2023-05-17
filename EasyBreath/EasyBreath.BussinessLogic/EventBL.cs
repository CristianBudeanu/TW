using EasyBreath.BussinessLogic.Core;
using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.Event;
using EasyBreath.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic
{
     public class EventBL : EventApi, IEvent
     {
          public Events GetEventById(int id)
          {
               return EventById(id);
          }

          public List<Events> GetEventList()
          {
               return AllEvents();
          }

          public ServiceResponse ValidateCreateEvent(Events events)
          {
               return ReturnCreateEventStatus(events);
          }

          public ServiceResponse ValidateDeleteEvent(Events events)
          {
               return ReturnDeleteEventStatus(events);
          }

          public ServiceResponse ValidateEditEvent(Events events)
          {
               return ReturnEditEventStatus(events);
          }
     }
}
