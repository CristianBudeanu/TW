using System.Web.Mvc;

namespace EasyBreath.web.Controllers
{
     public class HomeController : BaseController
     {
          // GET: Home Page
          public ActionResult Index()
          {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    System.Web.HttpContext.Current.Session.Clear();
                    //return RedirectToAction("LoginPage", "Auth");
               }
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