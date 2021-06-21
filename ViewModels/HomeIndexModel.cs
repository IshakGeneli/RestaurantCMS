using RestaurantCMS.Models;
using System.Collections.Generic;

namespace RestaurantCMS.ViewModels
{
    public class HomeIndexModel
    {
        public List<Personel> Personels { get; set; }
        public List<Dish> Dishes { get; set; }
        public Reservation Reservation { get; set; }

    }
}
