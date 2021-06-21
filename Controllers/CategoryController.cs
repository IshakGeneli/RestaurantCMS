using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RestaurantCMS.Business.Abstract;
using RestaurantCMS.Models;
using System.Collections.Generic;

namespace RestaurantCMS.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryService categoryService;
        IWebHostEnvironment webHost;

        public CategoryController(ICategoryService categoryService, IWebHostEnvironment webHost)
        {
            this.categoryService = categoryService;
            this.webHost = webHost;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult List()
        {
            List<Category> categories = categoryService.GetAll();
            return View(categories);
        }
    }
}
