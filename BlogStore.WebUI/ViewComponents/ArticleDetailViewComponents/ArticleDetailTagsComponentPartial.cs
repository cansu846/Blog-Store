using BlogStore.BussinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.ViewComponents.ArticleDetailViewComponents
{
    public class ArticleDetailTagsComponentPartial : ViewComponent
    {
        private readonly ITagService _tagService;

        public ArticleDetailTagsComponentPartial(ITagService tagService)
        {
            _tagService = tagService;
        }

        public IViewComponentResult Invoke()
        {
            var value = _tagService.TGetAll();
            return View(value);
        }
    }
}
