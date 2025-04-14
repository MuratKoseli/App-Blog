using System;


namespace AppBlog.Entity;

    public class Post
    {
        public int PostId { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; } // Post ekleme ksımında ekledik.
        public string? Content { get; set; }
        public string? Url { get; set; }//Post detaylarını url bilgisine göstermek için ekledik. Yani url bilgisinde 1,2 vb. değil de postun ismi yazacak
 
        public string? Image { get; set; }
        public DateTime PublishedOn { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }

        // Bir Post'umuz, Blogda ekleyeceğimiz bir blog kaydı olarak tanımlanacak.


        public User User { get; set; } = null!; // Yani her bir Post'un User bilgisi olacak

        public List<Tag> Tags { get; set; } = new List<Tag>(); //Her bir Post'un birden fazla Tag bilgisi olabilir.

        public List<Comment> Comments { get; set; } = new List<Comment>(); //Her bir Post'un birden fazla Comment'i olabilir.
    }
