using System.ComponentModel.DataAnnotations;

namespace BlogStore.WebUI.Models
{
    public class UserLoginViewModel
    {
        [Required(ErrorMessage="Kullanıcı adı boş bırakılamaz...")]
        public string Username { get; set; }

        [Required(ErrorMessage="Şifre boş bırakılamaz")]
        [DataType(DataType.Password)]   
        public string Password { get; set; }
    }
}
