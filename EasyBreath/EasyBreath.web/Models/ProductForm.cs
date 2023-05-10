using System.ComponentModel.DataAnnotations;

namespace EasyBreath.web.Models
{
    public class ProductForm
    {

        [Display(Name = "Name")]
        [Required(ErrorMessage = "You need to give product Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "You need to give product Price.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "You need to give product Amount.")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "You need to provide a product Thumbnail.")]
        [DataType(DataType.ImageUrl)]
        public string Thumbnail { get; set; }
    }
}