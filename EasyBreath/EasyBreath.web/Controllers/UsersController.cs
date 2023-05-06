using EasyBreath.BussinessLogic.DBModel;
using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.User;
using EasyBreath.Domain.Enum;
using EasyBreath.web.ActionAtributes;
using EasyBreath.web.Extensions;
using System.Linq;
using System.Web.Mvc;

namespace EasyBreath.web.Controllers
{
     public class UsersController : BaseController


     {
          private readonly ISession _session;

          public UsersController()
          {
               var bl = new BussinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();

          }
          [AdminMod]
          public ActionResult Index()
          {
               var db = new UserContext();
               var users = db.Users.ToList();
               return View(users);
          }
          
          public ActionResult Edit(int? id)
          {
               if(System.Web.HttpContext.Current.GetMySessionObject().Level == URole.ADMINISTRATOR)
               {
                    var db = new UserContext();
                    var user = db.Users.Find(id);
                    if (user == null)
                    {
                         return HttpNotFound();
                    }

                    return View(user);
               }

               else if (System.Web.HttpContext.Current.GetMySessionObject().Level == URole.USER)
               { 
                    var db = new UserContext();
                    var user = System.Web.HttpContext.Current.GetMySessionObject();
                    
                    if (user.Id != id)
                    {
                         return HttpNotFound();
                    }
                    else
                    {
                         UDbModel model = new UDbModel()
                         {
                              Username = user.Username,
                              Email = user.Email,
                              AccessLevel = user.Level,
                         };
                         return View(model);
                    }
               }
               else
               {
                    return HttpNotFound();
               }
          }

          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(UDbModel editUser)
          {
                    var sessionObject = System.Web.HttpContext.Current.GetMySessionObject();
                    var response = _session.ValidateEditUser(editUser);
                    if (response.Status)
                    {
                    if ((sessionObject.Id == editUser.Id))
                         {
                         sessionObject.Username = editUser.Username;
                         sessionObject.Email = editUser.Email;
                         sessionObject.Level = editUser.AccessLevel;
                         System.Web.HttpContext.Current.SetMySessionObject(sessionObject);
                         SessionStatus();
                         return RedirectToAction("LoginPage", "Auth");
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
          public ActionResult Delete(int? id)
          {
               var db = new UserContext();
               var user = db.Users.Find(id);
               if (user == null)
               {
                    return HttpNotFound();
               }

               return View(user);
          }

          [AdminMod]
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Delete(UDbModel deleteUser)
          {
               var response = _session.ValidateDeleteUser(deleteUser);
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
          public ActionResult Profile()
          {
               var user = System.Web.HttpContext.Current.GetMySessionObject();
               if (user == null)
               {
                    return HttpNotFound();
               }
               else
               {
                    UDbModel DBuser = new UDbModel
                    {
                         Username = user.Username,
                         Email = user.Email,
                         AccessLevel = user.Level,
                    };
                    return View(DBuser);
               }
          }
     }
}
