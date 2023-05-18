using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EasyBreath.Domain.Entities.Event
{
     public class Events
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int Id { get; set; }
          [Required]
          public string Name { get; set; }
          [Required]
          public DateTime DateEvent { get; set; }
          [Required]
          public string Description { get; set; }
          [Required]
          public string Location { get; set; }
          [Required]
          public string Thumbnail { get; set; }
     }
}
