using AppBlog.Entity;

namespace AppBlog.Data.Abstract
{
    public interface ITagRepository
    {
        IQueryable<Tag> Tags { get; }

        // Bu özellik, Tag nesnelerini sorgulamak için bir sorgulanabilir koleksiyon (IQueryable) sağlar.
        // Amaç: Veritabanındaki Tag nesnelerine erişimi ve sorgulamayı kolaylaştırmak. LINQ sorgularını yazarken kullanılacak.
        // Neden IQueryable ? Veritabanı sorgularını optimize etmek için kullanılır. LINQ sorguları, genellikle veritabanına gönderilen SQL sorgularına çevrilir ve yalnızca ihtiyaç duyulan veriler çekilir (deferred execution ile).

        void CreateTag(Tag tags);
        // Dışarıdan "Tag" tipinde bir "tags" alan bir veri. Veritabanına yeni bir (Tag) gönderi eklemek için kullanılır. 
    }
}

