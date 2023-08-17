using Microsoft.AspNetCore.Mvc;

namespace RestFullWebAPI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
