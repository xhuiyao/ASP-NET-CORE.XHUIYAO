using CoreDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieServices _movieServices;
        private readonly ICinemaServices _cinemaServices;

        public MovieController(IMovieServices movieServices,ICinemaServices cinemaServices)
        {
            _movieServices = movieServices;
            _cinemaServices = cinemaServices;
        }

        public async Task<IActionResult> Index(int cinemaId)
        {
            var cinema = await _cinemaServices.GetByIdAsync(cinemaId);
            ViewBag.Title = $"{cinema.Name}上映的电影有：";
            ViewBag.CinemaId = cinemaId;
            return View(await _movieServices.GetByCinemaAsync(cinemaId));
        }


        public IActionResult Add(int cinemaId)
        {
            ViewBag.Title = "添加电影";
            return View(new Movie { CinemaId = cinemaId });
        }

        public async Task<IActionResult> Edit(int movieId)
        {
            ViewBag.Title = "修改影片";
            var ViewModel = await _movieServices.GetMoviesById(movieId);
         
            return View(ViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Movie movie) 
        {
            if (ModelState.IsValid)
            {
                await _movieServices.AddAsync(movie);
            }
            return RedirectToAction("Index",new { cinemaId = movie.CinemaId});
        }


        [HttpPost]
        public async Task<IActionResult> Edits(Movie movie)
        {
            if (ModelState.IsValid)
            {
                await _movieServices.EditAsync(movie);
            }
            return RedirectToAction("Index", new { cinemaId = movie.CinemaId });
        }
    }
}
