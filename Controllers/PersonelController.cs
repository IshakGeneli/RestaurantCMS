using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RestaurantCMS.Business.Abstract;
using RestaurantCMS.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace RestaurantCMS.Controllers
{
    public class PersonelController : Controller
    {
        IPersonelService personelService;
        IWebHostEnvironment webHost;

        public PersonelController(IPersonelService personelService, IWebHostEnvironment webHost)
        {
            this.personelService = personelService;
            this.webHost = webHost;
        }

        public IActionResult Index()
        {
            List<Personel> personels = personelService.GetAll();
            return View(personels);
        }

        public IActionResult List()
        {
            List<Personel> personels = personelService.GetAll();
            return View(personels);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Personel personel)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = webHost.WebRootPath;
                string fileName = Path.GetFileNameWithoutExtension(personel.ImageFile.FileName);
                string extension = Path.GetExtension(personel.ImageFile.FileName);
                personel.Image = fileName += DateTime.Now.ToString("yymmssfff") + extension;
                string path = Path.Combine(wwwRootPath + "/images/personels/" + fileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    personel.ImageFile.CopyToAsync(stream);
                }

                personelService.Add(personel);
                return RedirectToAction(nameof(List));
            }


            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Personel personel = personelService.GetById(id);
            return View(personel);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Personel personel = personelService.GetById(id);
            return View(personel);
        }

        [HttpPost]
        public IActionResult Update(Personel personel)
        {


            if (ModelState.IsValid)
            {
                personelService.Update(personel);
                return RedirectToAction(nameof(List));
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            personelService.Delete(id);
            return RedirectToAction(nameof(List));
        }
    }
}
