using System.ComponentModel.DataAnnotations;

namespace CoreFolio.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen adınızı girin.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen soyadınızı girin.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Lütfen resim yolu ekleyin.")]
        public string ImageURL { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez.")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor.")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Mail boş geçilemez.")]
        public string Mail { get; set; }
    }
}
