using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.SessionState;

namespace EasyBreath.web.Controllers
{
    public class LoginController : Controller
    {
          private readonly ISession _session;
          public LoginController()
          {
               var bl = new BussinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();
          }
        public ActionResult Index()
        {
               var user = new ULoginData { Password = "Cristian", UserName = "Budeanu" };
               ServiceResponse UValidate = _session.ValidateUserCredential(user);

               if(UValidate.Status)
               {
                    var utoken = new UCookieData { UserName = user.UserName, Token = "abcd" };
                    CookieResponse cookie = _session.GenCookie(utoken);
               }
               return View();
        }
          [HttpPost]
          public ActionResult Index(Register e)
          {
               return View();
          }

          [HttpGet]
          public ActionResult Wellcome(Register e)
          {
               return View();
          }
     }
}