using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.Event;
using EasyBreath.web.ActionAtributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyBreath.web.Controllers
{
     public class EventController : Controller
     {
          // GET: Event
          private readonly ISession _session;
          private readonly IEvent _event;
          public EventController()
          {
               var bl = new BussinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();
               _event = bl.GetEventBL();
          }
          [HttpGet]
          public ActionResult Index()
          {
               return View(_event.GetEventList());
          }
          [HttpGet]
          [AdminMod]
          public ActionResult CreatePage()
          {
               ViewBag.Message = "Create Page";
               return View();
          }
          [HttpPost]
          [AdminMod]
          public ActionResult CreatePage(Events eventData)
          {
               if (!ModelState.IsValid)
               {
                    return View(eventData);
               }

               var response = _event.ValidateCreateEvent(eventData);
               if (response.Status)
               {
                    return RedirectToAction("Index", "Event");
               }
               else
               {
                    ModelState.AddModelError("Name product already exists", response.StatusMessage);
                    return View(eventData);
               }
          }

          [HttpGet]
          [AdminMod]
          public ActionResult Edit(int id)
          {
               var product = _event.GetEventById(id);
               if (product == null)
               {
                    return RedirectToAction("Index", "Event");
               }
               else
               {
                    return View(_event.GetEventById(id));
               }

          }
          [AdminMod]
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(Events editEvent)
          {
               var response = _event.ValidateEditEvent(editEvent);
               if (response.Status)
               {
                    return RedirectToAction("Index", "Event");
               }
               else
               {
                    ModelState.AddModelError("Event already exists", response.StatusMessage);
                    return View(editEvent);
               }
          }

          [AdminMod]
          [HttpGet]
          public ActionResult Delete(int id)
          {
               var product = _event.GetEventById(id);
               if (product == null)
               {
                    return RedirectToAction("Index", "Event");
               }
               else
               {
                    return View(_event.GetEventById(id));
               }
          }
          [AdminMod]
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Delete(Events deleteEvent)
          {
               var response = _event.ValidateDeleteEvent(deleteEvent);
               if (response.Status)
               {
                    return RedirectToAction("Index", "Event");
               }
               else
               {
                    ModelState.AddModelError("Event already exists", response.StatusMessage);
                    return View(deleteEvent);
               }
          }
     }
}