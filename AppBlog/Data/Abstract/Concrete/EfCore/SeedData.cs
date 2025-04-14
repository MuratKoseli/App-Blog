using AppBlog.Data.Concrete.EfCore;
using AppBlog.Entity;
using Microsoft.EntityFrameworkCore;

namespace AppBlog.Data.Abstract.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if (!context.Tags.Any())
                {
                    context.Tags.AddRange
                    (
                        new Tag { Text = "web programlama", Url = "web-programlama", Color = TagColors.warning },
                        new Tag { Text = "backend", Url = "backend", Color = TagColors.danger },
                        new Tag { Text = "frontend", Url = "frontend", Color = TagColors.secondary },
                        new Tag { Text = "fullstack", Url = "fullstack", Color = TagColors.primary },
                        new Tag { Text = "php", Url = "php", Color = TagColors.success }
                    );

                    context.SaveChanges();
                }

                if (!context.Users.Any())
                {
                    context.Users.AddRange
                    (
                        new User { UserName = "ahmetkececi", Name = "Ahmet Keçeci", Email = "info@ahmetkececi.com", Password = "123456", Image = "user1.jpg" },
                        new User { UserName = "ilhankor", Name = "İlhan Kor", Email = "info@ilhankor.com", Password = "123456", Image = "user2.jpg" }
                    );
                    context.SaveChanges();
                }

                if (!context.Posts.Any())
                {
                    context.Posts.AddRange
                    (
                        new Post
                        {
                            Title = "Asp.Net Core",
                            Description = "Asp.Net Core dersleri",
                            Content = "Asp.Net Core dersleri",
                            Url = "aspnet-core",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Tags = context.Tags.Take(3).ToList(),
                            Image = "1.jpg",
                            UserId = 1,
                            Comments = new List<Comment> {
                                new Comment {Text = "iyi bir kurs", PublishedOn = new DateTime(), UserId=1},
                                new Comment {Text = "başarılı bir kurs", PublishedOn = new DateTime(), UserId=2}

                            }
                        },

                        new Post
                        {
                            Title = "Php",
                            Description = "Asp.Net Core dersleri",
                            Content = "Php dersleri",
                            Url = "php",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Tags = context.Tags.Take(2).ToList(),
                            Image = "2.jpg",
                            UserId = 1
                        },

                        new Post
                        {
                            Title = "Java",
                            Description = "Asp.Net Core dersleri",
                            Content = "Java dersleri",
                            Url = "java",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2
                        },
                        new Post
                        {
                            Title = "JavaScript",
                            Description = "Asp.Net Core dersleri",
                            Content = "JavaScript dersleri",
                            Url = "js",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-40),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2
                        },
                        new Post
                        {
                            Title = "SQL",
                            Description = "Asp.Net Core dersleri",
                            Content = "SQL dersleri",
                            Url = "sql",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-50),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 1
                        },
                        new Post
                        {
                            Title = "React",
                            Description = "Asp.Net Core dersleri",
                            Content = "React dersleri",
                            Url = "react",
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-55),
                            Tags = context.Tags.Take(4).ToList(),
                            Image = "3.jpg",
                            UserId = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
// arayüze ihtiyaç duymadan database'e veri ekledik böylelikle ama detaylıca araştır