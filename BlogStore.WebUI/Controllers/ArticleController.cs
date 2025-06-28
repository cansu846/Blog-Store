using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        public IActionResult ArticleDetail(int id)
        {
            ViewBag.Id = id;
            return View();
        }
    }
}
