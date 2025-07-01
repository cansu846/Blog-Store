using BlogStore.EnitityLayer.Entities;
using BlogStore.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlogStore.WebUI.Controllers
{
    [Authorize]
    public class UserPasswordController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public UserPasswordController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager   )
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]  
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (!ModelState.IsValid) { 
                return View(model);  
            }
            //Şu an giriş yapmış olan kullanıcıyı alır.

            //User → ASP.NET Core’daki ClaimsPrincipal objesidir.
             var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("UserLogin","Login");
            }
            //Kullanıcının eski şifresini doğrular.

            //Yeni şifreyi atar.

            //Kurallara uygunsa işlemi tamamlar.

            //Başarısızsa result.Errors ile hata listesi döner.
            var result = await _userManager.ChangePasswordAsync(user,model.OldPassword,model.NewPassword);

            if (result.Succeeded) {
                //RefreshSignInAsync() ile oturum güncellenir
                //Kullanıcının şifresi değiştiği için RefreshSignInAsync ile oturumu yeniden oluşturur (çıkış yapmadan kalır).
                await _signInManager.RefreshSignInAsync((AppUser) user);
                ViewBag.message = "Şifreniz başarıyla değiştirildi";
                return RedirectToAction("GetProfile","Author"); 
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            return View(model);
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
                return RedirectToAction("Index", "Default");
            }

            ModelState.AddModelError("","Geçersiz kullanıcı adı veya şifre");
            return View(userLoginViewModel);
        }
    }
}
