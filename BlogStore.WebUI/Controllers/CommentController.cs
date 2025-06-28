using BlogStore.BussinessLayer.Abstract;
using BlogStore.EnitityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService _CommentService;

        public CommentController(ICommentService CommentService)
        {
            _CommentService = CommentService;
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
        public IActionResult CreateComment(Comment Comment) {
            _CommentService.TInsert(Comment);
            return RedirectToAction("Index");   
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
