using BlogStore.BussinessLayer.Abstract;
using BlogStore.DataAccessLayer.Abstract;
using BlogStore.EnitityLayer.Entities;
using BlogStore.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BlogStore.WebUI.Controllers
{
    [Authorize]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;

        public ArticleController(IArticleService articleService, UserManager<AppUser> userManager, ICategoryService categoryService)
        {
            _articleService = articleService;
            _userManager = userManager;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var articles = _articleService.TGetArticlesWithCategories();
            return View(articles);
        }

        [HttpGet]
        public IActionResult CreateArticle()
        {
            var categories = _categoryService.TGetAll();
            var model = new CreateArticleViewModel
            {
                Categories = categories.Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(CreateArticleViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // 🟡 Kategoriler yeniden yüklenmeli
                var categories = _categoryService.TGetAll();
                model.Categories = categories.Select(x => new SelectListItem
                {
                    Text = x.CategoryName,
                    Value = x.CategoryId.ToString()
                }).ToList();

                return View(model);
            }

            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            var article = new Article
            {
                Title = model.Title,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                //Slug = model.Slug,
                CategoryId = model.CategoryId,
                CreateDate = DateTime.Now,
                AppUserId = user.Id
            };

            _articleService.TInsert(article);

            TempData["Success"] = "Makale başarıyla eklendi.";
            return RedirectToAction("Index");
        }
        public IActionResult DeleteArticle(int id)
        {
            _articleService.TDelete(id);
            return RedirectToAction("Index");
        }

        public IActionResult ArticleDetail(string slug)
        {
            var article = _articleService.TGetArticleBySlug(slug);
            if (article == null) { 
                return NotFound();  
            }
            ViewBag.Id = article.ArticleId;
            return View();
        }
    }
}
