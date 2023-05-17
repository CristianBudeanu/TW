using EasyBreath.BussinessLogic.Core;
using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.ShoppingCart;
using EasyBreath.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EasyBreath.BussinessLogic.Core.ProductApi;

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

          public List<Cart> GetCartItemList(User user)
          {
               return AllCartItems(user);
          }
     }
}
