using BlogStore.BussinessLayer.Abstract;
using BlogStore.EnitityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.ViewComponents.Dashboard
{
    public class DashboardUserStatistics : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;

        public DashboardUserStatistics(IArticleService articleService, ICommentService commentService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _commentService = commentService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (User?.Identity?.Name == null)
            {
                // Giriş yapılmamışsa boş View döndür
                return View();
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
            {
                return View(); // kullanıcı veritabanında da yoksa yine boş view
            }
            ViewBag.user = user;    
            var articels = _articleService.TGetArticlesByAppUser(user.Id);
            var comments = _commentService.TGetCommentByUser(user.Id);
            ViewBag.articels = articels;
            ViewBag.comments = comments;
            ViewBag.articleCount = articels.Count;
            ViewBag.commentCount = comments.Count; 
            return View();
        }
    }
}
