using BlogStore.BussinessLayer.Abstract;
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
        private readonly ICommentService _CommentService;
        private readonly UserManager<AppUser> _userManager;
        public CommentController(ICommentService CommentService, UserManager<AppUser> userManager)
        {
            _CommentService = CommentService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _CommentService.TGetAll();    
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateComment()
        {
            return View();  
        }

        [HttpPost]  
        public async Task<IActionResult> CreateComment(Comment comment) {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user != null)
            {
                comment.AppUserId = user.Id;
                comment.UserNameSurname = user.Name + " " + user.Surname;
                _CommentService.TInsert(comment);
                return RedirectToAction("Index","Default");
            }
         return View();
        }
        public IActionResult DeleteComment(int id)
        {
            _CommentService.TDelete(id);   
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateComment(int id) {
            var value = _CommentService.TGetById(id);
            return View(value);  
        }

        [HttpPost]
        public IActionResult UpdateComment(Comment Comment)
        {
            _CommentService.TUpdate(Comment);
            return RedirectToAction("Index");
        }
    }
}
