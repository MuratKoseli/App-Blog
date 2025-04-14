using AppBlog.Entity;

namespace AppBlog.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> Posts { get; }

        // Bu özellik, Post nesnelerini sorgulamak için bir sorgulanabilir koleksiyon (IQueryable) sağlar.
        // Amaç: Veritabanındaki Post nesnelerine erişimi ve sorgulamayı kolaylaştırmak. LINQ sorgularını yazarken kullanılacak.
        // Neden IQueryable ? Veritabanı sorgularını optimize etmek için kullanılır. LINQ sorguları, genellikle veritabanına gönderilen SQL sorgularına çevrilir ve yalnızca ihtiyaç duyulan veriler çekilir (deferred execution ile).

        void CreatePost(Post post);
        // Dışarıdan "Post" tipinde bir "post" alan bir veri. Veritabanına yeni bir (Post)gönderi eklemek için kullanılır. 

        void EditPost(Post post);
    }
}

