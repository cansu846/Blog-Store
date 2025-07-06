using BlogStore.EnitityLayer.Entities;
using BlogStore.WebUI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlogStore.WebUI.Controllers
{
    public class UserPasswordController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IEmailSender _emailSender;

        public UserPasswordController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IEmailSender  emailSender )
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailSender = emailSender;
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


        [HttpGet]
        public async Task<IActionResult> ForgotPassword()
        {
            return View();
        }

        [HttpPost]  
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); 
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null) {
                ModelState.AddModelError("", "E-posta adresinize şifre sıfırlama bağlantısı gönderildi.");
                return View();
            }

            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var resetLink = Url.Action("ResetPassword","UserPassword", new
            {
                email = user.Email,
                token = token
            },Request.Scheme);

            await _emailSender.SendEmailAsync(user.Email, "Şifre Sıfırlama",
      $"<p>Şifrenizi sıfırlamak için <a href='{resetLink}'>buraya tıklayın</a>.</p>");

            ViewBag.Message = "E-posta adresinize şifre sıfırlama bağlantısı gönderildi.";
            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string email, string token)
        {
            return View(new ResetPasswordViewModel { Email=email, Token=token});  
        }

        [HttpPost]  
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); 
            }

            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null) {
                ModelState.AddModelError("","Kullanıcı bulunamadı");
                return View();
            }

            var result = await _userManager.ResetPasswordAsync(user,model.Token,model.NewPassword);

            if (result.Succeeded) {
                TempData["Success"] = "Şifreniz başarıyla değiştirildi.";
                return RedirectToAction("UserLogin","Login");
            }

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError("",item.Description);
            }

            return View(model); 
        }
    }
}
