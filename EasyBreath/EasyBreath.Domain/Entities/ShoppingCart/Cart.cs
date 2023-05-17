using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyBreath.Domain.Entities.Products;

namespace EasyBreath.Domain.Entities.ShoppingCart
{
     public class Cart
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          [Required]
          public int CartId { get; set; }
          [Required]
          public int Quantity { get; set; }
          [Required]
          public int ProductId { get; set; }

          public  Product Product { get; set; }

     }
}
