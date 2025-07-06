using BlogStore.BussinessLayer.Abstract;
using BlogStore.EnitityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogStore.WebUI.ViewComponents.Dashboard
{
    public class DashboardLastArticle : ViewComponent
    {
        private readonly IArticleService _articleService;
        private readonly UserManager<AppUser> _userManager;
        public DashboardLastArticle(IArticleService articleService, UserManager<AppUser> userManager)
        {
            _articleService = articleService;
            _userManager = userManager; 
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByAppUser(user.Id);
            ViewBag.values = values;    
            return View();
        }
    }
}
