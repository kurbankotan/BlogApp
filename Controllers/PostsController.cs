using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    public class PostsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}