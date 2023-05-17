using EasyBreath.BussinessLogic.DBModel;
using EasyBreath.Domain.Entities.Event;
using EasyBreath.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic.Core
{
     public class EventApi
     {
          public List<Events> AllEvents()
          {
               List<Events> events = null;
               using (var db = new EventsContext())
               {
                    events = db.Events.OrderByDescending(p => p.Name).ToList();
               }
               return events;
          }

          public Events EventById(int id)
          {
               using (var db = new EventsContext())
               {
                    var currentEvent = db.Events.FirstOrDefault(x => x.Id == id);
                    if (currentEvent == null)
                    {
                         return null;
                    }
                    return currentEvent;
               }
          }

          public ServiceResponse ReturnEditEventStatus(Events data)
          {
               var response = new ServiceResponse();
               using (var db = new EventsContext())
               {
                    try
                    {
                         var existingEvent = db.Events.FirstOrDefault(x => x.Id == data.Id);
                         if (existingEvent == null)
                         {
                              response.StatusMessage = "Event not found";
                              response.Status = false;

                              return response;
                         }


                         var duplicateEvent = db.Events.FirstOrDefault(u => (u.Name == data.Name) && u.Id != data.Id);
                         if (duplicateEvent != null)
                         {
                              response.StatusMessage = "Username or email already exists for another user";
                              response.Status = false;
                              return response;
                         }
                         else
                         {
                              existingEvent.Name = data.Name;
                              existingEvent.DateEvent = data.DateEvent;
                              existingEvent.Description = data.Description;
                              existingEvent.Location = data.Location;
                              existingEvent.Thumbnail = data.Thumbnail;

                              db.SaveChanges();


                              response.StatusMessage = "Product updated successfully";
                              response.Status = true;
                              return response;
                         }


                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while updating the Product";
                         response.Status = false;

                    }
                    return response;

               }
          }

          public ServiceResponse ReturnCreateEventStatus(Events data)
          {
               var response = new ServiceResponse();
               using (var db = new EventsContext())
               {
                    try
                    {
                         //     // Check if the user already exists in the database
                         var existingEvent = db.Events.FirstOrDefault(u => u.Id == data.Id);
                         if (existingEvent != null)
                         {
                              response.StatusMessage = "Event with this name already exists";
                              response.Status = false;
                              return response;
                         }

                         using (var db2 = new EventsContext())
                         {
                              db2.Events.Add(data);
                              db2.SaveChanges();
                         }

                         response.StatusMessage = "Event added successfully";
                         response.Status = true;
                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while adding the product";
                         response.Status = false;
                         //response.Exception = ex;
                    }
                    return response;
               }
          }

          public ServiceResponse ReturnDeleteEventStatus(Events deleteEvent)
          {
               var response = new ServiceResponse();
               using (var db = new EventsContext())
               {
                    try
                    {
                         var existingEvent = db.Events.FirstOrDefault(u => u.Id == deleteEvent.Id);
                         if (existingEvent == null)
                         {
                              response.StatusMessage = "Event not found";
                              response.Status = false;
                              return response;
                         }

                         db.Events.Remove(existingEvent);

                         response.StatusMessage = "Event deleted successfully";
                         response.Status = true;

                         db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while deleting the Product";
                         response.Status = false;
                    }
                    return response;
               }
          }
     }
}
