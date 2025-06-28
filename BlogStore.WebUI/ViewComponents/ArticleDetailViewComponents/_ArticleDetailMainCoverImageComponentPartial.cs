using BlogStore.BussinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.ViewComponents.ArticleDetailViewComponents
{
    public class _ArticleDetailMainCoverImageComponentPartial : ViewComponent
    {
      
        public IViewComponentResult Invoke()
        {
            return View();  
        }
    }
}
