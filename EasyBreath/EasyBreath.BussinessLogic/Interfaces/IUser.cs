using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic.Interfaces
{
     public interface IUser
     {
          User GetUserById(int id);
          List<User> GetUserList();
          ServiceResponse ValidateEditUser(User user);
          ServiceResponse ValidateDeleteUser(User user);
          //ServiceResponse ValidateNewPassword(User password);
     }
}
