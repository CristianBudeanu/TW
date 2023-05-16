using EasyBreath.Domain.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using EasyBreath.Domain.Entities.ShoppingCart;
using System.ComponentModel;

namespace EasyBreath.Domain.Entities.Products
{
     public class Product
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          [Required]
          public string Name { get; set; }
          [Required]
          public decimal Price { get; set; }
          [Required]
          public int Amount { get; set; }
          [Required]
          public string Thumbnail { get; set; }

     }
}
