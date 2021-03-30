using Microsoft.AspNetCore.Mvc;
using RestaurantCMS.Business.Abstract;
using RestaurantCMS.Models;
using System;
using System.Collections.Generic;

namespace RestaurantCMS.Controllers
{
    public class DishController : Controller
    {
        IDishService dishService;

        public DishController(IDishService dishService)
        {
            this.dishService = dishService;
        }
        public IActionResult Index()
        {
            List<Dish> dishes = dishService.GetDishes();       
            return View(dishes);
        }
    }
}
