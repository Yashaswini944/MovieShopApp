using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;

namespace MovieShop.MVC.Controllers
{
    public class CastController : Controller
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var cast = await _castService.GetCastDetails(id);
            if (cast == null) return NotFound();

            return View(cast);
        }
    }
}
