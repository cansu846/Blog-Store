using BlogStore.BussinessLayer.Abstract;
using BlogStore.DataAccessLayer.Abstract;
using BlogStore.EnitityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogStore.WebUI.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        private readonly ICommentService _commentService;

        public AuthorController(IArticleService articleService, ICategoryService categoryService, UserManager<AppUser> userManager, ICommentService commentService  )
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _userManager = userManager;
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.name = user.Name;
            ViewBag.surname = user.Surname;
            ViewBag.id = user.Id;
            ViewBag.imageUrl = user.ImageUrl;
            ViewBag.articleList = _articleService.TGetArticlesByAppUser(user.Id);
            ViewBag.commentList = _commentService.TGetCommentByUser(user.Id);
            return View(user);
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            List<SelectListItem> values = (from x in _categoryService.TGetAll()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();

            ViewBag.v = values;
            return View();
        }

        [HttpPost]  
        public async Task<IActionResult> CreateArticle(Article article)
        {
            var userProfile = await _userManager.FindByNameAsync(User.Identity.Name);
            article.AppUserId = userProfile.Id;
            article.CreateDate = DateTime.Now;  
            _articleService.TInsert(article);
            return RedirectToAction("Index","Default");
        }

        public async Task<IActionResult> MyArticleList()
        {
            var userProfile = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByAppUser(userProfile.Id);
            return View(values);
        }
    }
}
