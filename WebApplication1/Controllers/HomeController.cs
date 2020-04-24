using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;


namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICinemaServices _cinemaServices;
        public HomeController(ICinemaServices cinemaServices)
        {
            _cinemaServices = cinemaServices;
        }
        public async Task<IActionResult> Index() 
        {
            ViewBag.Title = "电影院";
            return View(await _cinemaServices.GetllallAsync());
        }

        public IActionResult Add()
        {
            ViewBag.Title = "添加电影院";
            return View(new Cinema());
        }

        public async Task<IActionResult> Edit(int cinemaId)
        {
            return View(await _cinemaServices.GetByIdAsync(cinemaId));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Cinema model)
        {
            if (ModelState.IsValid)
            {
                await _cinemaServices.AddAsync(model);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Cinema model)
        {
            if (ModelState.IsValid)
            {
                await _cinemaServices.EditAsync(model);
            }

            return RedirectToAction("Index");
        }


    }
}
