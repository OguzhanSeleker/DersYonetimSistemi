using Microsoft.AspNetCore.Mvc;

namespace DYS.WebClient.Controllers
{
    public class LessonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
