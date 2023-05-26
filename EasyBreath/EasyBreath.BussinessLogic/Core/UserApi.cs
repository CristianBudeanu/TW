using EasyBreath.BussinessLogic.DBModel;
using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic.Core
{
     public class UserApi
     {

          public List<User> AllUsers()
          {
               List<User> users = null;
               using (var db = new UserContext())
               {
                    users = db.Users.OrderByDescending(p => p.Username).ToList();
               }

               return users;
          }
          public User UserById(int id)
          {
               using (var db = new UserContext())
               {
                    var currentUser = db.Users.FirstOrDefault(x => x.Id == id);
                    if (currentUser == null)
                    {
                         return null;
                    }
                    return currentUser;
               }
          }
          public ServiceResponse ReturnEditUserStatus(User editUser)
          {
               var response = new ServiceResponse();
               using (var db = new UserContext())
               {
                    try
                    {
                         var existingUser = db.Users.FirstOrDefault(x => x.Id == editUser.Id);
                         if (existingUser == null)
                         {
                              response.StatusMessage = "User not found";
                              response.Status = false;

                              return response;
                         }


                         var duplicateUser = db.Users.FirstOrDefault(u => (u.Email == editUser.Email || u.Username == editUser.Username) && u.Id != editUser.Id);
                         if (duplicateUser != null)
                         {
                              response.StatusMessage = "Username or email already exists for another user";
                              response.Status = false;
                              return response;
                         }
                         else
                         {
                              existingUser.Username = editUser.Username;
                              existingUser.Email = editUser.Email;
                              existingUser.AccessLevel = editUser.AccessLevel;

                              db.SaveChanges();


                              response.StatusMessage = "User updated successfully";
                              response.Status = true;
                              return response;
                         }


                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while updating the user";
                         response.Status = false;

                    }
                    return response;

               }


          }
          public ServiceResponse ReturnDeleteUserStatus(User deleteUser)
          {
               var response = new ServiceResponse();
               using (var db = new UserContext())
               {
                    try
                    {
                         var existingUser = db.Users.FirstOrDefault(u => u.Id == deleteUser.Id);
                         if (existingUser == null)
                         {
                              response.StatusMessage = "User not found";
                              response.Status = false;
                              return response;
                         }

                         using (var dbC = new CartContext())
                         {
                              var items = dbC.Carts
                             .Where(item => item.CartId == deleteUser.Id)
                             .ToList();

                              foreach (var item in items)
                              {
                                   var userCartItem = dbC.Carts.FirstOrDefault(p => p.CartId == item.CartId);
                                   using (var dbP = new ProductsContext())
                                   {
                                        var product = dbP.Products.FirstOrDefault(p => p.Id == userCartItem.ProductId);
                                        product.Amount += userCartItem.Quantity;
                                        dbP.SaveChanges();
                                   }
                                   dbC.Carts.Remove(userCartItem);
                                   dbC.SaveChanges();

                              }
                         }

                         db.Users.Remove(existingUser);
                         db.SaveChanges();

                         response.StatusMessage = "User deleted successfully";
                         response.Status = true;
                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while deleting the user";
                         response.Status = false;
                    }
                    return response;
               }
          }
     }
}
