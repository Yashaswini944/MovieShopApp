using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IMovieService _movieService;

        public UserController(IUserService userService, IMovieService movieService)
        {
            _userService = userService;
            _movieService = movieService;
        }

        // ---------------------------------------------------------
        // PURCHASE MOVIE (GET)
        // ---------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> Purchase(int movieId)
        {
            var movie = await _movieService.GetMovieDetails(movieId);

            var model = new PurchaseRequestModel
            {
                MovieId = movieId,
                UserId = 1, // TEMP
                TotalPrice = movie.Price.GetValueOrDefault(),   // FIXED
                Title = movie.Title,
                PosterUrl = movie.PosterUrl
            };

            return View(model);
        }

        // ---------------------------------------------------------
        // PURCHASE MOVIE (POST)
        // ---------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> Purchase(PurchaseRequestModel model)
        {
            await _userService.PurchaseMovie(model);
            return RedirectToAction("Purchases");
        }

        // ---------------------------------------------------------
        // ADD REVIEW (GET)
        // ---------------------------------------------------------
        [HttpGet]
        public async Task<IActionResult> AddReview(int movieId)
        {
            var movie = await _movieService.GetMovieDetails(movieId);

            var model = new ReviewRequestModel
            {
                MovieId = movieId,
                UserId = 1, // TEMP
                Rating = 0,
                ReviewText = ""
            };

            return View(model);
        }

        // ---------------------------------------------------------
        // ADD REVIEW (POST)
        // ---------------------------------------------------------
        [HttpPost]
        public async Task<IActionResult> AddReview(ReviewRequestModel model)
        {
            await _userService.AddReview(model);
            return RedirectToAction("Details", "Movies", new { id = model.MovieId });
        }

        // ---------------------------------------------------------
        // FAVORITES
        // ---------------------------------------------------------
        public async Task<IActionResult> Favorites()
        {
            int userId = 1;
            var favorites = await _userService.GetFavorites(userId);
            return View(favorites);
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorite(FavoriteRequestModel model)
        {
            await _userService.AddFavorite(model);
            return RedirectToAction("Favorites");
        }

        // ---------------------------------------------------------
        // PURCHASE HISTORY
        // ---------------------------------------------------------
        public async Task<IActionResult> Purchases()
        {
            int userId = 1;
            var purchases = await _userService.GetPurchases(userId);
            return View(purchases);
        }
    }
}
