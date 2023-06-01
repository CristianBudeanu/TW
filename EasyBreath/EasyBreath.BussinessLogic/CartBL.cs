using EasyBreath.BussinessLogic.Core;
using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.Carts;
using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;
using System.Collections.Generic;


namespace EasyBreath.BussinessLogic
{
     public class CartBL : CartApi, ICart
     {
          public ServiceResponse ValidateAddToCart(Product item, int userId)
          {
               return ReturnAddToCart(item, userId);
          }

          public ServiceResponse ValidateDeleteFromCart(Product item, int userId)
          {
               return ReturnDeleteFromCart(item, userId);
          }

          public ServiceResponse ValidateBuyFromCart(int userId)
          {
               return ReturnBuyFromCart(userId);
          }

          public List<Cart> GetCartItemList(User user)
          {
               return AllCartItems(user);
          }
     }
}
