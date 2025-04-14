using System;


namespace AppBlog.Entity;

    public class User
    {
        
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? Name { get; set; }  //UsersController yani Login işlemlerinde eklendi.

    public string? Email { get; set; }//UsersController yani Login işlemlerinde eklendi.

    public string? Password { get; set; }//UsersController yani Login işlemlerinde eklendi.

    
    public string? Image { get; set; }

    // Her bir Post'un sahibi olacak. Bir Post'u sadece bir kişi yayınlayabilir.

    public List<Post> Posts { get; set; } = new List<Post>(); // Bir User birden fazla Post yayınlayabilir.

    public List<Comment> Comments { get; set; } = new List<Comment>(); // Bir User birden fazla Comment yapabilir. 
    }
