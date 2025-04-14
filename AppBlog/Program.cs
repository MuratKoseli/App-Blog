using AppBlog.Data.Abstract;
using AppBlog.Data.Abstract.Concrete.EfCore;
using AppBlog.Data.Concrete;
using AppBlog.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
// Controller'lar ile View'leri ilişkilendirdik. Controller ekledikten sonra ekleyebilirsin bunu.

builder.Services.AddDbContext<BlogContext>(options =>{
   
   options.UseSqlite(builder.Configuration["ConnectionStrings:sql_connecction"]);

    // options.UseSqlServer(connectionString);

    // options.UseNpgsql(connectionString);

});

builder.Services.AddScoped<IPostRepository, EfPostRepository>();
// IPostRepository ve EfPostRepository eklendikten sonra yazılır bu satır.
// IPostRepository: Bu, genellikle bir arabirimdir ve uygulamanın veri erişim katmanını soyutlamak için kullanılır.
// EfPostRepository: Bu, muhtemelen bir sınıftır ve IPostRepository arabirimini uygular. Örneğin, Entity Framework (EF) kullanarak veri tabanına erişimi sağlar.
// Biz IPostRepository üzerinden işlem yapıcaz her seferinde ancak EfPostRepository arka tarafta çağırılıp işlem yapacak. 
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options => {
   options.LoginPath = "/users/Login";//login olmadan postcreate sayfasına gitmek isteyen kişiyi bu sayfaya yönlendirir. 
});



var app = builder.Build();

app.UseStaticFiles();
// app.UseStaticFiles(); ifadesi, ASP.NET Core uygulamalarında statik dosyaların (örneğin, HTML, CSS, JavaScript, resimler, vb.) sunulmasını sağlar. Bu middleware, uygulamanın wwwroot gibi belirli bir klasörden gelen dosyaları istemcilere (tarayıcılara) göndermek için kullanılır. bootsrtap kurulumundan sonra yazılır.

app.UseRouting(); // Cookie eklendikten sonra yazılır. Sıralama bu şekilde olmalıdır mutlaka.
app.UseAuthentication(); // Cookie eklendikten sonra yazılır. Uygulamanın bizi tanımasını sağlar.   
app.UseAuthorization(); // Cookie eklendikten sonra yazılır. Uygulamanın belli bölümlerini kullanmamızı sağlayacak.




SeedData.TestVerileriniDoldur(app); 
// Seeddatayı çağırıp TestVerileriniDoldur diyerekt app'i parametre olarak geçicez. Dolayısıyla app aracılığıyla (builder.Services.AddDbContext<BlogContext>) buradaki Services konteynırına ulaşıp içinceki Context bilgisini alıcaz.


// localhost://posts/react-dersleri
// localhost://posts/java-dersleri

app.MapControllerRoute(
   name:"post_details",
   pattern: "posts/details/{url}",
   defaults: new {controller =  "Posts" , action = "Details"}     
);

// pattern: "posts/{url}" = posts(posts yerine istediğini yazabilirsin blog vs gibi) url'de sabit olan kısım sonrasında gelen url kısmı ise kursların belirlediğimiz url ismidir.
// !!!! PARANTEZ İÇİNDE OLMAYAN SABİT BİR DEĞERDİR!!!!

app.MapControllerRoute(
   name:"post_by_tag",
   pattern: "posts/tag/{tag}",
   defaults: new {controller =  "Posts" , action = "Index"}     
);

// taglere göre postları route eder.

app.MapControllerRoute(
    name: "defoult",
    pattern:"{controller=Home}/{action=Index}/{id?}"
);   

app.Run();
