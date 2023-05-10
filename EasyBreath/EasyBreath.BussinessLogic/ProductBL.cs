using EasyBreath.BussinessLogic.Core;
using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static EasyBreath.BussinessLogic.Core.ProductApi;

namespace EasyBreath.BussinessLogic
{
     public class ProductBL : ProductApi, IProduct
     {
          public List<Product> GetProductList()
          {
               return AllProducts();
          }
          public Product GetProductById(int id)
          {
               return ProductById(id);
          }
          public ServiceResponse ValidateEditProduct(Product product)
          {
               return ReturnEditProductStatus(product);
          }
          public ServiceResponse ValidateDeleteProduct(Product product)
          {
               return ReturnDeleteProductStatus(product);
          }
          public ServiceResponse ValidateCreateProduct(ProductData product)
          {
               return ReturnCreateProductStatus(product);
          }
     }
}
