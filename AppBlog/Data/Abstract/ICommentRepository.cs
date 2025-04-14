using AppBlog.Entity;

namespace AppBlog.Data.Abstract
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Comments { get; }

        // Bu özellik, Comment nesnelerini sorgulamak için bir sorgulanabilir koleksiyon (IQueryable) sağlar.
        // Amaç: Veritabanındaki Comment nesnelerine erişimi ve sorgulamayı kolaylaştırmak. LINQ sorgularını yazarken kullanılacak.
        // Neden IQueryable ? Veritabanı sorgularını optimize etmek için kullanılır. LINQ sorguları, genellikle veritabanına gönderilen SQL sorgularına çevrilir ve yalnızca ihtiyaç duyulan veriler çekilir (deferred execution ile).

        void CreateComment(Comment comment);
        // Dışarıdan "Comment" tipinde bir "comment" alan bir veri. Veritabanına yeni bir (Comment) gönderi eklemek için kullanılır. 
    }
}

