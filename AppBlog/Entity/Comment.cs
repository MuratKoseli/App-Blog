using System;


namespace AppBlog.Entity;

    public class Comment
    {
        
    public int CommentId { get; set; }
    public string? Text { get; set; }
    public DateTime PublishedOn { get; set; }

    // Her Post'a birden fazla Comment(yorum) yapılabilecek yani bir Comment bir Past'a ait olacak.

    public int PostId { get; set; }
    public Post Post { get; set; } = null!; // Bir Comment sadece bir Post'a ait olabilir. Id'leri eklemeyi unutma.

    public int UserId { get; set; }
    public User User { get; set; } = null!; // Her bir Comment'in bir User'ı olacak. Id'yi unutma.

}
