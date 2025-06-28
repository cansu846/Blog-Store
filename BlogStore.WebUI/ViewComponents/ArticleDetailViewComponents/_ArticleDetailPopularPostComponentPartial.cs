using BlogStore.BussinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleDetailPopularPostComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;
        public _ArticleDetailPopularPostComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetArticlesLast3();
            return View(values);  
        }
    }
}
