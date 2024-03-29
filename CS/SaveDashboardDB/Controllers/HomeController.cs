using Microsoft.AspNetCore.Mvc;
using SaveDashboardDB.Models;
using System.Diagnostics;

namespace SaveDashboardDB.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
