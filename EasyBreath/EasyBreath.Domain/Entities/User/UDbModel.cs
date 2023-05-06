﻿using EasyBreath.Domain.Enum;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EasyBreath.Domain.Entities.User
{
     public class UDbModel
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

          [DataType(DataType.Date)]
          public DateTime LoginDateTime { get; set; }

          [DataType(DataType.Date)]
          public DateTime RegisterDateTime { get; set; }

          [Required]
          public URole AccessLevel { get; set; }



     }
}
