using BlogStore.BussinessLayer.Abstract;
using BlogStore.EnitityLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _categoryService.TGetAll();    
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();  
        }

        [HttpPost]  
        public IActionResult CreateCategory(Category category) {
            _categoryService.TInsert(category);
            return RedirectToAction("Index");   
        }
        public IActionResult DeleteCategory(int id)
        {
            _categoryService.TDelete(id);   
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateCategory(int id) {
            var value = _categoryService.TGetById(id);
            return View(value);  
        }

        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            _categoryService.TUpdate(category);
            return RedirectToAction("Index");
        }
    }
}
