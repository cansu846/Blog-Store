using BlogStore.BussinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.ViewComponents.ArticleDetailViewComponents
{
    public class ArticleDetailMorePostComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;

        public ArticleDetailMorePostComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _articleService.TGetArticlesWithCategories();
            return View(values);  
        }
    }
}
