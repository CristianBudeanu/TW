using EasyBreath.BussinessLogic.DBModel;
using EasyBreath.Domain.Entities.Carts;
using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EasyBreath.BussinessLogic.Core
{
     public class CartApi
     {

          public List<Cart> AllCartItems(User user)
          {
               using (var db = new CartContext())
               {
                    try
                    {
                         var existingCart = db.Carts.FirstOrDefault(u => u.CartId == user.Id);
                         if (existingCart == null)
                         {
                              return new List<Cart>();
                         }
                         else
                         {
                              var items = db.Carts
                                  .Where(item => item.CartId == existingCart.CartId)
                                  .OrderBy(item => item.ProductId)
                                  .ToList();

                              foreach (var item in items)
                              {
                                   using (var db1 = new ProductsContext())
                                   {
                                        var product = db1.Products.FirstOrDefault(p => p.Id == item.ProductId);
                                        item.Product = product;
                                   }
                              }

                              return items.Select(item => new Cart
                              {
                                   CartId = item.CartId,
                                   Product = item.Product,
                                   Quantity = item.Quantity
                              }).ToList();
                         }
                    }
                    catch (Exception ex)
                    {
                         return new List<Cart>();
                    }

               }
          }

          public ServiceResponse ReturnAddToCart(Product data, int userId)
          {
               var response = new ServiceResponse();
               using (var db = new CartContext())
               {
                    try
                    {
                         //     // Check if the user already exists in the database
                         var existingCart = db.Carts.FirstOrDefault(u => (u.CartId == userId) && (u.ProductId == data.Id));
                         if (existingCart != null && data.Amount > 0)
                         {
                              // var existingItem = existingCart.Items.FirstOrDefault(idp => idp.Product == data.Product);

                              if (existingCart.ProductId == data.Id)
                              {

                                   existingCart.Quantity++;

                                   response.StatusMessage = "Item added to cart";
                                   response.Status = true;

                              }
                              else
                              {
                                   existingCart.ProductId = data.Id;
                                   existingCart.Quantity = 1;
                                   existingCart.Product = data;
                                   //db.Carts.Add(existingCart);
                                   response.StatusMessage = "Item added to cart";
                                   response.Status = true;

                              }

                         }
                         else if (data.Amount > 0)
                         {
                              var newCart = new Cart()
                              {
                                   CartId = userId,
                                   ProductId = data.Id,
                                   Quantity = 1,

                              };
                              db.Carts.Add(newCart);
                              response.StatusMessage = "Item added to cart";
                              response.Status = true;
                         }
                         else
                         {
                              response.StatusMessage = "An error occurred while adding the item";
                              response.Status = false;
                         }
                         db.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while adding the item";
                         response.Status = false;
                         //response.Exception = ex;
                    }
                    return response;
               }
          }

          public ServiceResponse ReturnDeleteFromCart(Product data, int userId)
          {
               var response = new ServiceResponse();
               using (var db = new CartContext())
               {
                    try
                    {
                         //     // Check if the user already exists in the database
                         var existingCart = db.Carts.FirstOrDefault(u => (u.CartId == userId) && (u.ProductId == data.Id));
                         if (existingCart != null)
                         {
                              using (var dbP = new ProductsContext())
                              {
                                   var currentProduct = dbP.Products.FirstOrDefault(x => x.Id == data.Id);
                                   if (currentProduct == null)
                                   {
                                        response.StatusMessage = "Product not found";
                                        response.Status = false;
                                        return response;
                                   }
                                   else
                                   {
                                        currentProduct.Amount += existingCart.Quantity;
                                        dbP.SaveChanges();
                                   }
                              }
                              db.Carts.Remove(existingCart);
                              db.SaveChanges();
                              response.StatusMessage = "Product deleted successfully";
                              response.Status = true;
                              return response;

                         }
                         response.StatusMessage = "Product not found";
                         response.Status = false;
                         return response;

                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while adding the item";
                         response.Status = false;
                         //response.Exception = ex;
                    }
                    return response;
               }
          }

          public ServiceResponse ReturnBuyFromCart(int userId)
          {
               var response = new ServiceResponse();
               using (var db = new CartContext())
               {
                    try
                    {
                         //     // Check if the user already exists in the database
                         var existingCart = db.Carts.FirstOrDefault(u => (u.CartId == userId));
                         if (existingCart != null)
                         {
                              var carts = db.Carts
                             .Where(item => item.CartId == userId)
                             .ToList();

                              foreach (var item in carts)
                              {       
                                   db.Carts.Remove(item);
                              }
                              
                              db.SaveChanges();
                              response.StatusMessage = "Products from cart buyed successfully";
                              response.Status = true;
                              return response;

                         }
                         response.StatusMessage = "Cart not found";
                         response.Status = false;
                         return response;

                    }
                    catch (Exception ex)
                    {
                         response.StatusMessage = "An error occurred while buyng from cart";
                         response.Status = false;
                         //response.Exception = ex;
                    }
                    return response;
               }
          }

       }
}
