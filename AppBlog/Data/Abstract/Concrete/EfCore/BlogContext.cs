using System;
using AppBlog.Entity;
using Microsoft.EntityFrameworkCore;

namespace AppBlog.Data.Concrete.EfCore;

public class BlogContext : DbContext
// SQLite'ı ekledikten sonra yani database providers işleminden sonra DbContext'ten türetiriz.
{

    public BlogContext(DbContextOptions<BlogContext> options) : base(options)
    {

    }

    //Dışarıdan bir connection string göndermek için bunu yazdık. 

    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Comment> Comments => Set<Comment>();

    internal IQueryable<Comment> GetComments()
    {
        throw new NotImplementedException();
    }
}
