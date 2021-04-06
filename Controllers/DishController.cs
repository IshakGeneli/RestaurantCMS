using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RestaurantCMS.Business.Abstract;
using RestaurantCMS.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace RestaurantCMS.Controllers
{
    public class DishController : Controller
    {
        IDishService dishService;
        IWebHostEnvironment webHost;

        public DishController(IDishService dishService, IWebHostEnvironment webHost)
        {
            this.dishService = dishService;
            this.webHost = webHost;
        }
        public IActionResult Index()
        {
            List<Dish> dishes = dishService.GetAll();
            return View(dishes);
        }
        public IActionResult List()
        {
            List<Dish> dishes = dishService.GetAll();
            return View(dishes);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Dish dish)
        {
           
            if (ModelState.IsValid)
            {
                string wwwRootPath = webHost.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(dish.ImageFile.FileName);
                string extension = Path.GetExtension(dish.ImageFile.FileName);
                dish.Image = fileName += DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/menu/" + fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    dish.ImageFile.CopyToAsync(stream);
                }

                dishService.Add(dish);
                return RedirectToAction(nameof(List));
            }


            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Dish dish = dishService.GetById(id);
            return View(dish);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Dish dish = dishService.GetById(id);
            return View(dish);
        }

        [HttpPost]
        public IActionResult Update(Dish dish)
        {
            

            if (ModelState.IsValid)
            {
                //string wwwRootPath = webHost.WebRootPath;
                //string fileName = Path.GetFileName(dish.ImageFile.FileName);
                //string path = Path.Combine(wwwRootPath + "/images/menu/" + fileName);
                //using (var stream = new FileStream(path, FileMode.Create))
                //{
                //    dish.ImageFile.CopyToAsync(stream);
                //}
                dishService.Update(dish);
                return RedirectToAction(nameof(List));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            dishService.Delete(id);
            return RedirectToAction(nameof(List));
        }
    }
}
