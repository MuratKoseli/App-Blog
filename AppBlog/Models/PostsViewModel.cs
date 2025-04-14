using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppBlog.Entity;

namespace AppBlog.Models
{
    public class PostsViewModel
    {
        public List<Post> Posts { get; set; } = new();

        // public List<Tag> Tags { get; set; } = new();
    }
}
// Bir Model hem Post hem de Tag listesini taşıyor. Şimdi bu modeli Posts/Index sayfasında @model List<Post> yerine tanımlayabilirim.


// ViewComponents ekledikten sonra  hem postları hem de tagleri  Posts/Index üzerinde tanımlamadığımız için artık bu kısma gerek kalmadı bu yüzden public List<Tag> Tags { get; set; } = new(); kısmını kaldırdık(hata verdiği için kaldırmadık ama kullanmadıkta). Ama yine de aynı sayfada iki farklı modeli bu şekilde birleştirebileceğimizi hatırla.