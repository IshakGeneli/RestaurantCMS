using System;
using System.ComponentModel.DataAnnotations;

namespace RestaurantCMS.Models
{
    public class Reservation
    {
        [Display(AutoGenerateField = true, Name = "Rezervasyon Numarası")]
        public int ReservationId { get; set; }

        [Required]
        [Display(Name = "Rezervasyon Sahibi")]
        public string FullName { get; set; }

        [Required]
        [Display(Name = "Telefon")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Rezervasyon Tarihi")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Kişi Sayısı")]
        public int NumPerson { get; set; }
    }
}
