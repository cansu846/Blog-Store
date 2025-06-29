using BlogStore.BussinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.ViewComponents.ArticleDetailViewComponents
{
    public class ArticleDetailCommentListContent : ViewComponent
    {
        private readonly ICommentService _commentService;

        public ArticleDetailCommentListContent(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.TGetCommentsByArticle(id);
            return View(values);
        }
    }
}
