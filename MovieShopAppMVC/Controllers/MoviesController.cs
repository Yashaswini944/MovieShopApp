using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        public async Task<IActionResult> Genre(int id)
        {
            var movies = await _movieService.GetMoviesByGenre(id);
            return View("MovieList", movies);
        }
    }
}
