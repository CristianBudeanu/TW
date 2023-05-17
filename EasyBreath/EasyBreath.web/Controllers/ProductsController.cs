
using EasyBreath.BussinessLogic.DBModel;
using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.User;
using EasyBreath.Domain.Enum;
using EasyBreath.web.ActionAtributes;
using EasyBreath.web.Extensions;
using EasyBreath.web.Models;
using System.Linq;
using System.Web.Mvc;
using static EasyBreath.BussinessLogic.Core.ProductApi;

namespace EasyBreath.web.Controllers
{
     public class ProductsController : BaseController
     {
          private readonly ISession _session;
          private readonly IProduct _product;
          public ProductsController()
          {
               var bl = new BussinessLogic.BusinessLogic();
               _session = bl.GetSessionBL();
               _product = bl.GetProductBL();


          }
          [HttpGet]
          public ActionResult Index()
          {
               return View(_product.GetProductList());
          }

          [HttpGet]
          [AdminMod]
          public ActionResult CreatePage()
          {
               ViewBag.Message = "Create Page";
               return View();
          }
          [HttpPost]
          [AdminMod]
          public ActionResult CreatePage(ProductForm product)
          { 
               if (!ModelState.IsValid)
               {
                    return View(product);
               }
               var productData = new ProductData
               {
                    Name = product.Name,
                    Price = product.Price,
                    Amount = product.Amount,
                    Thumbnail = product.Thumbnail
               };
               var response = _product.ValidateCreateProduct(productData);
               if (response.Status)
               {
                    return RedirectToAction("Index", "Products");
               }
               else
               {
                    ModelState.AddModelError("Name product already exists", response.StatusMessage);
                    return View(product);
               }
          }
          [HttpGet]
          [AdminMod]
          public ActionResult Edit(int id)
          {
               var product = _product.GetProductById(id);
               if (product == null)
               {
                    return RedirectToAction("Index", "Products");
               }
               else
               {
                    return View(_product.GetProductById(id));
               }
               
          }
          [AdminMod]
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit(Product editProduct)
          {
               var response = _product.ValidateEditProduct(editProduct);
               if (response.Status) { 
                         return RedirectToAction("Index", "Products");
                    }
                    else
                    {
                    ModelState.AddModelError("Product already exists", response.StatusMessage);
                    return View(editProduct);
               }
          }


          [AdminMod]
          [HttpGet]
          public ActionResult Delete(int id)
          {
               var product = _product.GetProductById(id);
               if (product == null)
               {
                    return RedirectToAction("Index", "Products");
               }
               else
               {
                    return View(_product.GetProductById(id));
               }
          }
          [AdminMod]
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Delete(Product deleteProduct)
          {
               var response = _product.ValidateDeleteProduct(deleteProduct);
               if (response.Status)
               {
                    return RedirectToAction("Index", "Products");
               }
               else
               {
                    ModelState.AddModelError("Product already exists", response.StatusMessage);
                    return View(deleteProduct);
               }
          }


     }
}

