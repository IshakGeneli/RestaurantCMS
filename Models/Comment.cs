using System;

namespace RestaurantCMS.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int DishId { get; set; }
        public string Content { get; set; }
        public short Rating { get; set; }
        public DateTime Date { get; set; }

    }
}
