using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantCMS.Models
{
    public class Dish
    {
        public int DishId { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public Category Category { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string DishName { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public string Description { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]

        public double Price { get; set; }
        [Required(ErrorMessage = "Boş Geçilemez")]
        public short Rating { get; set; }
        public bool Featured { get; set; }

    }
}
