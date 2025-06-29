using BlogStore.BussinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.ViewComponents
{
    public class _FooterComponentPartial:ViewComponent
    {
        private readonly IArticleService _articleService;

        public _FooterComponentPartial(IArticleService articleService)
        {
            _articleService = articleService;
        }

        public IViewComponentResult Invoke() {
            var values = _articleService.TGetArticlesLast3();
            return View(values); 
        } 
    }
}
