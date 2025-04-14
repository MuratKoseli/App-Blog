using AppBlog.Entity;

namespace AppBlog.Data.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> Users { get; }

        // Bu özellik, User nesnelerini sorgulamak için bir sorgulanabilir koleksiyon (IQueryable) sağlar.
        // Amaç: Veritabanındaki User nesnelerine erişimi ve sorgulamayı kolaylaştırmak. LINQ sorgularını yazarken kullanılacak.
        // Neden IQueryable ? Veritabanı sorgularını optimize etmek için kullanılır. LINQ sorguları, genellikle veritabanına gönderilen SQL sorgularına çevrilir ve yalnızca ihtiyaç duyulan veriler çekilir (deferred execution ile).

        void CreateUser(User user);
        // Dışarıdan "User" tipinde bir "users" alan bir veri. Veritabanına yeni bir (User) gönderi eklemek için kullanılır. 
    }
}

