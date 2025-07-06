using BlogStore.EnitityLayer.Entities;
using BlogStore.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogStore.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult UserLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UserLogin(UserLoginViewModel userLoginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginViewModel);
            }
            var result = await _signInManager.PasswordSignInAsync(userLoginViewModel.Username, userLoginViewModel.Password, true,false);
            
            if (result.Succeeded)
            {
                return RedirectToAction("GetProfile", "Author");
            }

            ModelState.AddModelError("","Geçersiz kullanıcı adı veya şifre");
            return View(userLoginViewModel);
        }

      
        public async Task<IActionResult> Logout() {
            await _signInManager.SignOutAsync();
            return RedirectToAction("UserLogin","Login");
        }
    }
}
