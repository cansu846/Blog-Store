using BlogStore.BussinessLayer.Abstract;
using BlogStore.EnitityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.ViewComponents.ArticleDetailViewComponents
{
    public class ArticleDetailLeaveComment : ViewComponent
    {

        public IViewComponentResult Invoke(int id)
        {
            ViewBag.articleId = id;
            return View();
        }
    }
}
