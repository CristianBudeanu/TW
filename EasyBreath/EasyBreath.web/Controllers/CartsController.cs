using EasyBreath.BussinessLogic.DBModel;
using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.User;
using EasyBreath.web.ActionAtributes;
using EasyBreath.web.Extensions;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI;

namespace EasyBreath.web.Controllers
{
     public class CartsController : BaseController
     {

          private readonly ICart _cart;
          private readonly IProduct _product;
          private readonly IUser _user;

          public CartsController()
          {
               var bl = new BussinessLogic.BusinessLogic();
               _cart = bl.GetCartBL();
               _product = bl.GetProductBL();
               _user = bl.GetUsertBL();
          }

          [AuthorizedMod]
          [HttpGet]
          public ActionResult Index(int userId)
          {
               //var currentUser = System.Web.HttpContext.Current.GetMySessionObject();
               if (System.Web.HttpContext.Current.GetMySessionObject().Id == userId)
               {
                    using (var db = new UserContext())
                    {
                         var user = db.Users.FirstOrDefault(id => id.Id == userId);
                         return View(_cart.GetCartItemList(user));
                    }
               }
               else
               {
                    return RedirectToAction("Index", "Carts", new {userId});
               }
               
          }


          [AuthorizedMod]
          [HttpPost]
          public ActionResult DeleteFromCart(int productId, int userId)
          {

               var product = _product.GetProductById(productId);
               if (product != null)
               {
                    var response = _cart.ValidateDeleteFromCart(product, userId);
                    if (response.Status)
                    {
                         return RedirectToAction("Index", "Carts", new {userId});
                    }
                    return RedirectToAction("Index", "Home");

               }
               else
               {
                    return RedirectToAction("Index", "Home");
               }
          }

          [AuthorizedMod]
          [HttpPost]
          public async Task<ActionResult> BuyFromCart(int userId)
          {   
               _cart.ValidateBuyFromCart(userId);
               await Task.Delay(2500);
               return RedirectToAction("Index", "Carts", new {userId});
          }

          [AuthorizedMod]
          [HttpPost]
          public ActionResult AddToCart(int productId, int userId)
          {

               var product = _product.GetProductById(productId);
               if (product != null)
               {
                    //var item = new ShoppingItemCart();

                    //item.ProductId = productId;
                    //item.CartId = userId;
                    //item.Quantity = 1;

                    var response = _cart.ValidateAddToCart(product, userId);

                    if (response.Status)
                    {
                         using (var db = new ProductsContext())
                         {
                              var currentProduct = db.Products.FirstOrDefault(x => x.Id == productId);
                              if (currentProduct == null)
                              {
                                   ModelState.AddModelError("", response.StatusMessage);
                              }
                              else
                              {
                                   currentProduct.Amount--;
                                   db.SaveChanges();
                              }
                         }
                         return RedirectToAction("Index", "Products");
                    }
                    else
                    {
                         // There was an error adding the product
                         ModelState.AddModelError("", response.StatusMessage);
                         return RedirectToAction("Index", "Products");
                    }
               }
               else
               {
                    return RedirectToAction("Index", "Products");
               }

          }
     }
}