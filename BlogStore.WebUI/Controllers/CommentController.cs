using BlogStore.BussinessLayer.Abstract;
using BlogStore.BussinessLayer.AnalizeCommentService;
using BlogStore.EnitityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogStore.WebUI.Controllers
{
    [Authorize]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;
        private readonly UserManager<AppUser> _userManager;
        public CommentController(ICommentService commentService, UserManager<AppUser> userManager)
        {
            _commentService = commentService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _commentService.TGetAll();
            return View(values);
        }



        [HttpGet]
        public IActionResult CreateComment()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(Comment comment)
        {
           
            var user = await _userManager.FindByNameAsync(User.Identity.Name);

            if (user != null)
            {
                comment.AppUserId = user.Id;
                comment.UserNameSurname = user.Name + " " + user.Surname;
                comment.CommentDate = DateTime.Now;
                comment.IsValid = true; // veya moderasyon bekleme sistemi
                _commentService.TInsert(comment);
                TempData["message"] = "Yorumunuz başarıyla eklendi!";
                return RedirectToAction("Index", "Article");
            }
            return View();
        }

        public IActionResult DeleteComment(int id)
        {
            _commentService.TDelete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateComment(int id)
        {
            var value = _commentService.TGetById(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateComment(Comment Comment)
        {
            _commentService.TUpdate(Comment);
            return RedirectToAction("Index");
        }
    }
}
