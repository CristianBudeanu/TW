using BusinessLogic;
using BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BusinessLogic
{
     public class BussinesLogic
     {
          public ISession GetSessionBL()
          {
               return new SessionBL();
          }
     }
}
