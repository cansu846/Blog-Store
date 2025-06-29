using BlogStore.BussinessLayer.Abstract;
using BlogStore.DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IActionResult ArticleDetail(string slug)
        {
            var article = _articleService.TGetArticleBySlug(slug);
            if (article == null) { 
                return NotFound();  
            }
            ViewBag.Id = article.ArticleId;
            return View();
        }
    }
}
