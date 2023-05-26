using EasyBreath.BussinessLogic.DBModel;
using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.User;
using EasyBreath.Domain.Enum;
using EasyBreath.web.ActionAtributes;
using EasyBreath.web.Extensions;
using System;
using System.Linq;
using System.Web.Mvc;

namespace EasyBreath.web.Controllers
{
     public class UsersController : BaseController


     {
          private readonly IUser _user;
          private readonly ISession _session;
          public UsersController()
          {
               var bl = new BussinessLogic.BusinessLogic();
               _user = bl.GetUsertBL();
               _session = bl.GetSessionBL();
          }
          [AdminMod]
          public ActionResult Index()
          {
               return View(_user.GetUserList());
          }

          [AuthorizedMod]
          public ActionResult Edit(int id)
          {
               if (System.Web.HttpContext.Current.GetMySessionObject().AccessLevel == URole.ADMINISTRATOR )
               {
                    var user = _user.GetUserById(id);
                    if (user == null)
                    {
                         return RedirectToAction("Index", "Products");
                    }
                    else
                    {
                         return View(_user.GetUserById(id));
                    }
               }

               else if (System.Web.HttpContext.Current.GetMySessionObject().AccessLevel == URole.USER)
               {
                    var db = new UserContext();
                    var user = System.Web.HttpContext.Current.GetMySessionObject();

                    if (user.Id != id)
                    {
                         return HttpNotFound();
                    }
                    else
                    {
                         return View(_user.GetUserById(id));
                    }
               }
               else
               {
                    return HttpNotFound();
               }
          }

          [AuthorizedMod]
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(User editUser)
          {
                    var sessionObject = System.Web.HttpContext.Current.GetMySessionObject();
                    var response = _user.ValidateEditUser(editUser);
                    if (response.Status)
                    {
                    if ((sessionObject.Id == editUser.Id))
                         {
                         sessionObject.Username = editUser.Username;
                         sessionObject.Email = editUser.Email;
                         sessionObject.AccessLevel = editUser.AccessLevel;

                         var cookieResponse = _session.GenCookie(sessionObject.Username);
                         if (cookieResponse != null)
                         {
                              ControllerContext.HttpContext.Response.Cookies.Add(cookieResponse.Cookie);
                              return RedirectToAction("Index", "Home");
                         }
                         else
                         {
                              throw new Exception();
                         }
                    }
                    else
                    {
                         return RedirectToAction("Index", "Home");
                    }
               }
               else
               {
                    ModelState.AddModelError("Username or email already exists", response.StatusMessage);
                    return View(editUser);
               }
          }

          [AdminMod]
          public ActionResult Delete(int id)
          {
               var user = _user.GetUserById(id);
               if (user == null)
               {
                    return HttpNotFound();
               }

               return View(user);
          }

          [AdminMod]
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Delete(User deleteUser)
          {
               var response = _user.ValidateDeleteUser(deleteUser);
               if (response.Status)
               {
                    return RedirectToAction("Index", "Home");
               }
               else
               {
                    ModelState.AddModelError("", response.StatusMessage);
                    return View(deleteUser);
               }
          }

          [HttpGet]
          [AuthorizedMod]
          public ActionResult Profile()
          {
               var user = System.Web.HttpContext.Current.GetMySessionObject();
               if (user == null)
               {
                    return HttpNotFound();
               }
               else
               {
                    User DBuser = new User
                    {
                         Username = user.Username,
                         Email = user.Email,
                         AccessLevel = user.AccessLevel,
                    };
                    return View(DBuser);
               }
          }
     }
}
