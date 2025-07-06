using System.ComponentModel.DataAnnotations;

namespace BlogStore.WebUI.Models
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage ="E-posta zorunludur...")]
        [EmailAddress(ErrorMessage ="Gecerli bir e-posta giriniz...")]  
        public string Email { get; set; }
    }
}
