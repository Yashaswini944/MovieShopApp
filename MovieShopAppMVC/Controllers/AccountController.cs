using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginRequestModel model)
        {
            var user = await _accountService.Login(model);
            if (user == null)
            {
                ViewBag.Error = "Invalid credentials";
                return View();
            }

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model)
        {
            var result = await _accountService.Register(model);
            if (result == null)
            {
                ViewBag.Error = "Email already exists";
                return View();
            }

            return RedirectToAction("Login");
        }
    }
}
