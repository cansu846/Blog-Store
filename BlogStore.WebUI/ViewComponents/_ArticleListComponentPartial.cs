using BlogStore.BussinessLayer.Abstract;
using BlogStore.DataAccessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.ViewComponents
{
    public class _ArticleListComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;

        public _ArticleListComponentPartial(IArticleService articleService)
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
