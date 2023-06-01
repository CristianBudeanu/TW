using EasyBreath.Domain.Entities.Carts;
using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;
using System.Collections.Generic;


namespace EasyBreath.BussinessLogic.Interfaces
{
     public interface ICart
     {
          ServiceResponse ValidateAddToCart(Product item, int userId);
          ServiceResponse ValidateDeleteFromCart(Product item, int userId);
          ServiceResponse ValidateBuyFromCart(int userId);
          List<Cart> GetCartItemList(User user);
     }
}
