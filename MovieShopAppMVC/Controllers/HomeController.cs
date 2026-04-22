using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;

namespace MovieShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService _movieService;

        public HomeController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _movieService.GetTopRatedMovies();
            return View(movies);
        }
    }
}
