using EasyBreath.BussinessLogic.Interfaces;

namespace EasyBreath.BussinessLogic
{
     public class BusinessLogic
     {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }
          public IProduct GetProductBL()
          {
               return new ProductBL();
          }
          public IUser GetUsertBL()
          {
               return new UserBL();
          }
          public ICart GetCartBL()
          {
               return new CartBL();
          }
          public IEvent GetEventBL()
          {
               return new EventBL();
          }
     }
}
