namespace RestaurantCMS.Models
{
    public class Dish
    {
        public int DishId { get; set; }
        public int CategoryId { get; set; }
        public string DishName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public short Rating { get; set; }
        public bool Featured { get; set; }

    }
}
