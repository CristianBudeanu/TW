using EasyBreath.web.ActionAtributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EasyBreath.web.Controllers
{
    public class ProductController : BaseController
    {
          // GET: Product
        [AdminMod]
        public ActionResult AddProduct()
        {
               SessionStatus();
               if ((string)System.Web.HttpContext.Current.Session["LoginStatus"] != "login")
               {
                    return RedirectToAction("LoginPage", "Auth");
               }
               else
               {

               }
               return View();
        }
    }
}