using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
