using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;

namespace AppBlog.Models
{
    public class LoginViewModels
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
        public string? Email { get; set; }


        [Required]
        [StringLength(10, ErrorMessage = "{0} alanı en az {2} karakter uzunluğunda olmalıdır.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]

        public string? Password { get; set; }
    }

    // Login giriş ekranı için model oluşturduk ve bu modeli kullandık.
}