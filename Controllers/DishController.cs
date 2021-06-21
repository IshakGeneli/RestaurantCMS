using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RestaurantCMS.Business.Abstract;
using RestaurantCMS.Models;
using RestaurantCMS.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;

namespace RestaurantCMS.Controllers
{
    [Authorize]
    public class DishController : Controller
    {
        IDishService dishService;
        ICategoryService categoryService;
        IWebHostEnvironment webHost;

        public DishController(IDishService dishService, ICategoryService categoryService, IWebHostEnvironment webHost)
        {
            this.dishService = dishService;
            this.categoryService = categoryService;
            this.webHost = webHost;
        }
        public IActionResult Index()
        {
            List<Dish> dishes = dishService.GetAll();
            List<Category> categories = categoryService.GetAll();
            DishCategoryModel model = new DishCategoryModel
            {
                Dishes = dishes,
                Categories = categories
            };
            return View(model);
        }
        public IActionResult List()
        {
            List<Dish> dishes = dishService.GetAll();
            return View(dishes);
        }

        [HttpGet]
        public IActionResult ListByCategory(int id)
        {
            List<Dish> dishes = dishService.GetByCategoryId(id);
            List<Category> categories = categoryService.GetAll();
            DishCategoryModel model = new DishCategoryModel
            {
                Dishes = dishes,
                Categories = categories
            };
            return View(model);
        }


        [HttpGet]
        public IActionResult Add()
        {
            List<Category> categories = categoryService.GetAll();

            DishCategoryModel model = new DishCategoryModel
            {
                Categories = categories
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(DishCategoryModel model)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = webHost.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(model.Dish.ImageFile.FileName);
                string extension = Path.GetExtension(model.Dish.ImageFile.FileName);
                model.Dish.Image = fileName += DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/menu/" + fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    model.Dish.ImageFile.CopyToAsync(stream);
                }

                dishService.Add(model.Dish);
                return RedirectToAction(nameof(List));
            }


            return View(model);
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
