using System;


namespace AppBlog.Entity;

public enum TagColors
{
    primary, danger, warning, success, secondary
    // her bir tag'in farklı renk olması için enum yöntemini kullanıyoruz.
}

    public class Tag
    {
        public int TagId { get; set; }
        public string? Text { get; set; }

        // Her bir Post bilgisi Tag'lere sahip olacak. Örneğin 10 adet etiketi ilgilendiren post olmuş olabilir.
         public string? Url { get; set; } //neden eklediğimiz post entitiy'de yazılı. şimdi seed data kısmına giderek url leri ekle

        public TagColors? Color { get; set; }
        //Tag'lerin renkleri için bunu ekledik. Magration etmeyi unutma. 

        public List<Post> GetPosts { get; set; } = new List<Post>(); // Her bir Tag birden fazla posta ait olabilir.
    }
