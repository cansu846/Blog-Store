using BlogStore.BussinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleDetailAboutAuthorComponentPartial : ViewComponent
    {
        private readonly IArticleService _articleService;
        public _ArticleDetailAboutAuthorComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }
        public IViewComponentResult Invoke(int id)
        {
            var value = _articleService.TGetAppUserByArticleId(id);
            return View(value);  
        }
    }
}
