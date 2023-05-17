using EasyBreath.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyBreath.Domain.Entities.User
{
     public class User
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          [Required]
          public string Username { get; set; }
          [Required]
          public string Password { get; set; }
          [Required]
          public string Email { get; set; }

          [Column(TypeName = "datetime2")]
          public DateTime LoginDateTime { get; set; }

          [Column(TypeName = "datetime2")]
          public DateTime RegisterDateTime { get; set; }

          [Required]
          public URole AccessLevel { get; set; }
     }
}
