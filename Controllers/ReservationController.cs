using Microsoft.AspNetCore.Mvc;
using RestaurantCMS.Business.Abstract;
using RestaurantCMS.Models;
using System.Collections.Generic;

namespace RestaurantCMS.Controllers
{
    public class ReservationController : Controller
    {
        private IReservationService _reservationService;
        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        public IActionResult Index(bool check = false)
        {
            List<Reservation> reservations = _reservationService.GetAll();
           
            return View(reservations);
        }

        public IActionResult Add()
        {
            return PartialView("ReservationAdd");
        }


        [HttpPost]
        public IActionResult Add(Reservation reservation)
        {
            _reservationService.Add(reservation);
            return RedirectToAction("Index", "Home");
        }
    }
}
