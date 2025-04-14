using AppBlog.Data.Abstract;
using AppBlog.Data.Concrete.EfCore;
using AppBlog.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppBlog.Data.Abstract.Concrete.EfCore
{
    public class EfCommentRepository : ICommentRepository
    {
        private BlogContext _context;

         public EfCommentRepository(BlogContext context)
         {
            _context = context;
         }   

        public IQueryable<Comment> Comments => _context.GetComments();

        public void CreateComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }
    }
}