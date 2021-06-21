using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantCMS.Business.Abstract;
using RestaurantCMS.Models;
using RestaurantCMS.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;

namespace RestaurantCMS.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IDishService dishService;
        IPersonelService personelService;
        public HomeController(ILogger<HomeController> logger, IDishService dishService, IPersonelService personelService)
        {
            _logger = logger;
            this.dishService = dishService;
            this.personelService = personelService;
        }

        public IActionResult Index()
        {
            List<Dish> dishes = dishService.GetByFeaturedItem();
            List<Personel> personels = personelService.GetAll();

            HomeIndexModel model = new HomeIndexModel()
            {
                Dishes = dishes,
                Personels = personels
            };
            return View(model);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }  

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
