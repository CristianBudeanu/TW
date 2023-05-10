using EasyBreath.BussinessLogic.Core;
using EasyBreath.BussinessLogic.Interfaces;
using EasyBreath.Domain.Entities.Products;
using EasyBreath.Domain.Entities.Response;
using EasyBreath.Domain.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.BussinessLogic
{
     public class UserBL : UserApi, IUser
     {
          public ServiceResponse ValidateEditUser(User data)
          {
               return ReturnEditUserStatus(data);
          }

          public ServiceResponse ValidateDeleteUser(User user)
          {
               return ReturnDeleteUserStatus(user);
          }

          public List<User> GetUserList()
          {
               return AllUsers();
          }
          public User GetUserById(int id)
          {
               return UserById(id);
          }

     }
}
