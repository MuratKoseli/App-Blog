using System.ComponentModel.DataAnnotations;
using System.IO.Pipelines;

namespace AppBlog.Models
{
    public class PostCreateViewModel
    {
        public int PostId { get; set; }

        [Required]
        [Display(Name = "Post Title")]
        public string? Title { get; set; }
        
        [Required]
        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Required]
        [Display(Name = "Content")]
        public string? Content { get; set; }

        [Required]
        [Display(Name = "Url")]
        public string? Url { get; set; }

        public bool IsActive { get; set; }
    }

    // Login giriş ekranı için model oluşturduk ve bu modeli kullandık.
}