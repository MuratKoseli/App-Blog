using AppBlog.Data.Abstract;
using AppBlog.Data.Concrete.EfCore;
using AppBlog.Entity;

namespace AppBlog.Data.Concrete.EfCore
{
    public class EfPostRepository : IPostRepository
    {

        private BlogContext _context;

        public EfPostRepository(BlogContext context)
        {
            _context = context;
        }


        public IQueryable<Post> Posts => _context.Posts;

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void EditPost(Post post)
        {
           var entity = _context.Posts.FirstOrDefault(i => i.PostId == post.PostId);

           if(entity != null)
           {
            entity.Title = post.Title;
            entity.Description = post.Description;
            entity.Content = post.Content;
            entity.Url = post.Url;
            entity.IsActive = post.IsActive;

            _context.SaveChanges();

           }
        }



        //( IPostRepository implement intarface ettiğinde bu versiyonu kendisi verir. sonrasında değiştirirsin.
        // public IQueryable<Post> Posts => throw new NotImplementedException();

        // public void CreatePost(Post post)
        // {
        //     throw new NotImplementedException();
        // })
    }
}