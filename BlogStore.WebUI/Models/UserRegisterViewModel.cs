using System.ComponentModel.DataAnnotations;

namespace BlogStore.WebUI.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Ad alanı girilmesi zorunludur")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Soyisim alanı girilmesi zorunludur")]
        public string Surname { get; set; }
        [Required(ErrorMessage ="Mail alanı boş bırakılamaz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Kullanıcı adı boş bırakılamaz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password alanı boş bırakılamaz")]
        public string Password { get; set; }
    }
}
