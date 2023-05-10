using EasyBreath.BussinessLogic.Core;
using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EasyBreath.BussinessLogic.Core.ProductApi;

namespace EasyBreath.BussinessLogic.Interfaces
{
     public interface IProduct
     {
          Product GetProductById(int id);
          List<Product> GetProductList();
          ServiceResponse ValidateEditProduct(Product product);
          ServiceResponse ValidateDeleteProduct(Product product);
          ServiceResponse ValidateCreateProduct(ProductData product);
     }
}
