using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.Areas.Default.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]/[action]")]
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
