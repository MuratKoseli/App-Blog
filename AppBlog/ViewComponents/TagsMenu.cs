using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AppBlog.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppBlog.ViewComponents
{
    public class TagsMenu : ViewComponent
    {
        private ITagRepository _tagRepository;

        public TagsMenu(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public async Task<IViewComponentResult>  InvokeAsync()
        {
            return View(await _tagRepository.Tags.ToListAsync());
        }
    }
}
// TagsMenu, bir blog uygulamasında etiketlerin bir menü şeklinde gösterilmesi için oluşturulmuş bir bileşendir. Veri kaynağı (örneğin veritabanındaki etiketler), ITagRepository üzerinden alınır ve ViewComponent'e bağlı bir görünümde görüntülenir. Etiket menüsü gibi özellikleri dinamik hale getirmek için idealdir. Fakat;
// ViewComponent'lerin kullanım alanlarına tekrardan bak, birçok alanda kullanılabilir