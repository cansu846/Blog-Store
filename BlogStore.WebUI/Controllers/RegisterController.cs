using BlogStore.EnitityLayer.Entities;
using BlogStore.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRegisterViewModel userRegisterViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userRegisterViewModel);
            }
            AppUser appUser = new AppUser()
            {
                ImageUrl = "test",
                Description = "test",
                Name = userRegisterViewModel.Name,
                Email = userRegisterViewModel.Email,
                Surname = userRegisterViewModel.Surname,
                UserName = userRegisterViewModel.Username
            };

            var result = await _userManager.CreateAsync(appUser, userRegisterViewModel.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("UserLogin", "Login");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();
        }
    }
}
