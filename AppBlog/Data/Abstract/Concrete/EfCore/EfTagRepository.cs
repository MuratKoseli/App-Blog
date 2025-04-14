using AppBlog.Data.Abstract;
using AppBlog.Data.Concrete.EfCore;
using AppBlog.Entity;

namespace AppBlog.Data.Concrete.EfCore
{
    public class EfTagRepository : ITagRepository
    {

        private BlogContext _context;

        public EfTagRepository(BlogContext context)
        {
            _context = context;
        }

        public IQueryable<Tag> Tags => _context.Tags;

        public void CreateTag(Tag tags)
        {
            _context.Tags.Add(tags);
            _context.SaveChanges();
        }

// !!!!! bu sayfadan sonra program.cs sayfasına uygulamanın bunu tanıması için;
// builder.Services.AddScoped<ITagRepository, EfTagRepository>(); komutunu yazılmalı.



        //( IPostRepository implement intarface ettiğinde bu versiyonu kendisi verir. sonrasında değiştirirsin.
        // public IQueryable<Post> Posts => throw new NotImplementedException();

        // public void CreatePost(Post post)
        // {
        //     throw new NotImplementedException();
        // })
    }
}