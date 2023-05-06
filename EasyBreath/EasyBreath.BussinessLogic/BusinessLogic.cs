using EasyBreath.BussinessLogic.Interfaces;

namespace EasyBreath.BussinessLogic
{
     public class BusinessLogic
     {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }
     }
}
