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

namespace EasyBreath.BussinessLogic.Interfaces
{
     public interface ICart
     {
          ServiceResponse ValidateAddToCart(Product item, int userId);
          ServiceResponse ValidateDeleteFromCart(Product item, int userId);
          List<ShoppingItemCart> GetCartItemList(User user);
     }
}
