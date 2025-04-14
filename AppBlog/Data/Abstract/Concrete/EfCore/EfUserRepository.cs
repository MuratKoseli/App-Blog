using AppBlog.Data.Abstract;
using AppBlog.Entity;

namespace AppBlog.Data.Concrete.EfCore
{
    public class EfUserRepository : IUserRepository
    {

        BlogContext _context;

        public EfUserRepository(BlogContext context)
        {
            _context = context;
        }
        public IQueryable<User> Users => _context.Users;

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}