using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;
using EasyBreath.web.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

               return View(UValidate);

          }

          [HttpPost]
          public ActionResult Index(LoginData data)
          {
               if (ModelState.IsValid)
               {
                    ULoginData uLogin = new ULoginData
                    {
                         UserName = data.Username,
                         Password = data.Password,
                    };

                    var response = _session.ValidateUserCredential(uLogin);
                    if (response.Status)
                    {
                         return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         ModelState.AddModelError("", response.StatusMessage);
                         return View();
                    }
               }
               return View();
          }

          [HttpGet]
          public ActionResult Login()
          {
               return View(new LoginData());
          }

     }
}