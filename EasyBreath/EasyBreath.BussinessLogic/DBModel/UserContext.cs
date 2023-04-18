using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EasyBreath.Domain.Entities;
using EasyBreath.Domain.Entities.User;

namespace EasyBreath.BussinessLogic.DBModel
{
     public class UserContext : DbContext
     {
          public UserContext() : base("name=EasyBreathDB")
          {
               
          }
          public DbSet<UDbModel> Users { get; set; }

     }
}
