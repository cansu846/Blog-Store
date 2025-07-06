using System.ComponentModel.DataAnnotations;

namespace BlogStore.WebUI.Models
{
    public class ResetPasswordViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Token { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Compare("NewPassword",ErrorMessage ="Şifreler uyuşmuyor")]
        [DataType(DataType.Password)]   
        public string ConfirmPassword { get; set; }
    }
}
