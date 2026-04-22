using Microsoft.AspNetCore.Mvc;
using ApplicationCore.Contracts.Services;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> Reports()
        {
            var reports = await _adminService.GetAllReports();
            return View(reports);
        }

        public async Task<IActionResult> Users()
        {
            var users = await _adminService.GetAllUsers();
            return View(users);
        }

        public async Task<IActionResult> Resolve(int id)
        {
            await _adminService.ResolveReport(id);
            return RedirectToAction("Reports");
        }
    }
}
