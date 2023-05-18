using EasyBreath.BussinessLogic.DBModel;
using EasyBreath.Domain.Entities.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class EventsDbInitializer
     {
          public static void Seed()     
          {
               DateTime dt1 = new DateTime(2023, 05, 12, 5, 10, 20);
               DateTime dt2 = new DateTime(2023, 06, 04, 5, 10, 20);
               DateTime dt3 = new DateTime(2023, 12, 29, 5, 10, 20);
               using (EventsContext db = new EventsContext())
               {
                    if (db.Database.Exists())
                    {
                         if (!db.Events.Any())
                         {
                              var events = new List<Events>
                              {
                                 new Events()
                                 {
                                      Name = "Health Screenings",
                                      DateEvent = dt1,
                                      Location = "Chisinau",
                                      Description = "These quick and easy wellness events are great because of their relatively low cost and high impact. " +
                                      "Most people hate going to the doctor, but if the doctor is right there… why not? In fact, you don’t even need a doctor. " +
                                      "Nurses or nurse practitioners can do the job of taking blood pressure, screening for cholesterol, testing blood sugar, etc. " +
                                      "The biggest benefit to you is the immediate perception that your event is going the extra mile to put attendees’ well-beings first.",
                                      Thumbnail = "https://nwpc.com//wp-content/uploads/2020/03/mens-health-screening-checklist.jpg"
                                 },


                              new Events()
                              {
                                      Name = "Healthy Buffet",
                                      DateEvent = dt2,
                                      Location = "Chisinau",
                                      Description = "The key to an attendee’s heart is through their stomach ” so why not show your guests you care? Most event spreads are " +
                                      "chock-full of fried foods, sweet desserts, and other assorted treats that may taste great, but aren’t exactly healthy.\r\n\r\nHealthy meals" +
                                      " make great additions to wellness events because they aren’t too tough to pull off. Breakfast buffets can include things like egg white omelettes, " +
                                      "fruit, and granola. Serving lunch? Look no further than the salad. And for dinner, serve up some sautÃ©ed veggies and protein. Your guests (and their stomachs!) will thank you.",
                                      Thumbnail = "https://food.fnr.sndimg.com/content/dam/images/food/fullset/2018/1/24/0/FN_Healthy-Buffet-table-Strategies-iStock_s4x3.jpg.rend.hgtvcom.616.462.suffix/1516829955078.jpeg"
                              },


                              new Events()
                              {
                                      Name = "Mental Wellness Events",
                                      DateEvent = dt3,
                                      Location = "Ialoveni",
                                      Description = "Wellness isn’t just a physical thing ” mental well-being is just as important to your guests. So hire a motivational speaker that really speaks " +
                                      "to the reason your attendees are there. Sure, you may not be able to afford famous speakers like Tony Robbins or Grant Cardone, but other speakers still pack plenty" +
                                      " of inspiration.\r\n\r\nTry looking up a few TED Talks on the subject of choice as many of these speakers are available at a much lower price. And if that’s out of the " +
                                      "budget, there are always great local speakers you can put on stage.",
                                      Thumbnail = "https://assets-global.website-files.com/6145f7156a1337613524d548/63a44411a91863c3e5dc9c20_Blog%20creatives%20new-03.png"
                              }
                         };
                              events.ForEach(p => db.Events.Add(p));
                              db.SaveChanges();
                         }
                    }

               }
          }
          }
}
