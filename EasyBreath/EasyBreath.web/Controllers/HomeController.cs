using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyBreath.web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
         {
             return View();
         }
        public ActionResult Portfolio()
         {
             return View();
         }          
         public ActionResult Diete()
         {
              return View();
         }
         public ActionResult Vitamins()
         {
              return View();
         }
         public ActionResult Shop()
          {
               return View(); 
          }
          public ActionResult Sport()
          {
               return View();
          }
          public ActionResult Statistic() 
          {
               return View();
          }
          public ActionResult Event() 
          {
               return View();
          }
          public ActionResult Nutrition()
          {
               return View();
          }
    }
}