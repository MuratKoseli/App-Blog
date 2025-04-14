using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;

namespace AppBlog.Models
{
    public class RegisterViewModels
    {
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string? UserName { get; set; }

        [Required]
        [Display(Name = "Ad Soyad")]
        public string? Name { get; set; }
        
        [Required]
        [Display(Name = "Eposta")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        [StringLength(10,ErrorMessage ="{0} alanı en az {2} karakter uzunluğunda olmalıdır.", MinimumLength =5)]
        public string? Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare(nameof(Password), ErrorMessage ="Şifre Eşleşmiyor.")]//bu component modeliyle "Password" kısmını karşılaştırıyoruz!!! 
        public string? ConfirmPassword { get; set; }
    }


}