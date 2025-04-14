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
    public class NewPosts : ViewComponent
    {
        private IPostRepository _postRepository;

        public NewPosts(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View(await _postRepository
                                .Posts
                                .OrderByDescending(p=>p.PublishedOn)
                                .Take(5)
                                .ToListAsync());
                // Amacımız yeni Post'ları sıralamak bu yüzden öncelikle OrderByDescending(p=>p.PublishedOn) satırıyla Post'ları tarihine göre son ekleneenden eskşye göre sıraladık(PublishedOn database'de DateTime'a verdiğimiz isim) sonrasında Take(5) komutuyla da son 5 postu almasını istedik.
        }
    }
}