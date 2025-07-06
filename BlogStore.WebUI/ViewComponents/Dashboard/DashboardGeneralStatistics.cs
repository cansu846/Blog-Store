using BlogStore.BussinessLayer.Abstract;
using BlogStore.EnitityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogStore.WebUI.ViewComponents.Dashboard
{
    public class DashboardGeneralStatistics : ViewComponent
    {
        private readonly IArticleService _articleService;
        private readonly ICommentService _commentService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public DashboardGeneralStatistics(IArticleService articleService, ICommentService commentService, ICategoryService categoryService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _commentService = commentService;
            _categoryService = categoryService;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var articleCount = _articleService.TGetAll().Count;
            var commentCount = _commentService.TGetAll().Count;
            var categoryCount = _categoryService.TGetAll().Count;
            var userCount = _userManager.Users.Count();

            ViewBag.ArticleCount = articleCount;    
            ViewBag.CommentCount = commentCount;    
            ViewBag.CategoryCount = categoryCount;
            ViewBag.UserCount = userCount;  
           return View();
        }
    }
}
