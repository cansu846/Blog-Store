using BlogStore.BussinessLayer.Abstract;
using BlogStore.DataAccessLayer.Abstract;
using BlogStore.EnitityLayer.Entities;
using BlogStore.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace BlogStore.WebUI.Controllers
{
    [Authorize]
    public class AuthorController : Controller
    {
        private readonly IArticleService _articleService;
        private readonly ICategoryService _categoryService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ICommentService _commentService;

        public AuthorController(IArticleService articleService, ICategoryService categoryService, UserManager<AppUser> userManager, ICommentService commentService, SignInManager<AppUser> signInManager    )
        {
            _articleService = articleService;
            _categoryService = categoryService;
            _userManager = userManager;
            _commentService = commentService;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            // Tüm yazarları çek (roller varsa sadece "Writer" rolündekileri alabilirsin)
            var users = _userManager.Users.ToList();

            var authors = users.Select(user => new AuthorCardViewModel
            {
                FullName = $"{user.Name} {user.Surname}",
                ImageUrl = user.ImageUrl ?? "/images/default-user.png",
                Description = string.IsNullOrEmpty(user.Description) ? "Henüz açıklama eklenmedi." : user.Description,
                Email = user.Email,
                ArticleCount = _articleService.TGetArticlesByAppUser(user.Id)?.Count ?? 0,
                UserName = user.UserName,
            }).ToList();

            return View(authors);
        }

        [HttpGet("Author/Detail/{username}")]
        public async Task<IActionResult> Detail(string username)
        {
            if (string.IsNullOrEmpty(username)) return NotFound();

            var user = await _userManager.FindByNameAsync(username);
            if (user == null) return NotFound();

            var model = new AuthorDetailViewModel
            {
                FullName = $"{user.Name} {user.Surname}",
                ImageUrl = user.ImageUrl ?? "/images/default-user.png",
                Description = user.Description ?? "Yazar henüz bir açıklama eklemedi.",
                Email = user.Email,
                Articles = _articleService.TGetArticlesByAppUser(user.Id).Select(a => new ArticleSummaryViewModel
                {
                    Title = a.Title,
                    Slug = a.Slug,
                    CreatedDate = a.CreateDate
                }).ToList() ?? new()
            };

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> GetProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return View("Error");
            }
            ViewBag.name = user.Name;
            ViewBag.surname = user.Surname;
            ViewBag.id = user.Id;
            ViewBag.imageUrl = user.ImageUrl;
            ViewBag.articleList = _articleService.TGetArticlesByAppUser(user.Id);
            ViewBag.commentList = _commentService.TGetCommentByUser(user.Id);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            UpdateProfileViewModel model = new UpdateProfileViewModel();
            if (user != null)
            {
                model.Name = user.Name;
                model.Surname = user.Surname;
                model.ImageUrl = user.ImageUrl;
                model.Description = user.Description;
                model.Email = user.Email;
                model.UserName = user.UserName;
                return View(model);
            }
            return View(); 
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UpdateProfileViewModel updateProfileViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(updateProfileViewModel);
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user == null)
            {
                ModelState.AddModelError("", "Kullanıcı Bulunamadı");
                return View();
            }
            user.Name = updateProfileViewModel.Name;
            user.Surname = updateProfileViewModel.Surname;
            user.ImageUrl = updateProfileViewModel.ImageUrl;
            user.Description = updateProfileViewModel.Description;
            user.Email = updateProfileViewModel.Email;
            user.Email = updateProfileViewModel.Email;
            user.UserName = updateProfileViewModel.UserName;

            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                TempData["Success"] = "Profil bilgileriniz başarıyla güncellendi";
                await _signInManager.SignOutAsync();
                return RedirectToAction("UserLogin", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                }
            }

            return View(updateProfileViewModel);
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
            return RedirectToAction("Index", "Default");
        }

        public async Task<IActionResult> MyArticleList()
        {
            var userProfile = await _userManager.FindByNameAsync(User.Identity.Name);
            var values = _articleService.TGetArticlesByAppUser(userProfile.Id);
            return View(values);
        }
    }
}
