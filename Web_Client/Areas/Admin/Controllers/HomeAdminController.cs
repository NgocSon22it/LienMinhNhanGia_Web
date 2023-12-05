using Microsoft.AspNetCore.Mvc;

namespace Web_Client.Areas.Admin.Controllers
{
    public class HomeAdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
