using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using AppBlog.Data.Abstract;
using AppBlog.Entity;
using AppBlog.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AppBlog.Controllers
{
    // [Route("[controller]")]
    public class PostsController : Controller
    {
        private IPostRepository _postRepository;
        // private ITagRepository _tagRepository;

        private ICommentRepository _commentRepository;

        public PostsController(IPostRepository postRepository, ICommentRepository commentRepository) //(IPostRepository postRepository, ITagRepository tagRepository)
        {
            _postRepository = postRepository;
            //  _tagRepository = tagRepository;
            _commentRepository = commentRepository;
        }


        public async Task<IActionResult> Index(string tag)//tag url'sini ekledikten sonra ekliyoruz.
        {
            var claims = User.Claims;  //UsersController'a Claimler eklendikten sonra ekledik bu satırı.
            // Claims bir liste içindeki elemanları ClaimsType ile bu liste içerisinden tek tek alabiliriz(Name, Id gibi şeyleri)

            var posts = _postRepository.Posts.Where(i => i.IsActive);

            if (!string.IsNullOrEmpty(tag))
            {
                posts = posts.Where(x => x.Tags.Any(t => t.Url == tag));
            }
            return View(
                new PostsViewModel
                {
                    Posts = await posts.ToListAsync()
                    // Posts = _postRepository.Posts.ToList() //Tag url sini eklediğimiz için yeni kod üst kısımdaki gibi oldu.
                    // Tags = _tagRepository.Tags.ToList() // PostsViewModel'de tags'i kaldırdığımız için buradan da kaldırdık
                }
            );
        }


        // public async Task<IActionResult> Details(int? id)
        // {
        //     return View(await _postRepository.Posts.FirstOrDefaultAsync(p=>p.PostId ==id));
        // } 
        // url ekledikten sonra id ye göre değil url ye göre sorguluyoruz.
        public async Task<IActionResult> Details(string Url)
        {
            return View(await _postRepository
                                .Posts
                                .Include(x => x.Tags)// bu satırı taglere color ekledikten sonra her bir dersin detay sayfasında taglarin rengi özelliğini almak için ekledik. Şimdi Posts/Detail.cshtml ye git ve foreach döngüsünü yaz.
                                .Include(x => x.Comments)
                                .ThenInclude(x => x.User)// Bu Include ve ThenInclude satırlarını yorum jpg lerini ve yorumları seed data'ya ekledikten sonra yorumları listelemek için ekliyoruz. Şimdi Posts/Detail.cshtml ye git ve foreach döngüsünü yaz. her gittiğimiz yorumun userını da yüklememiz için thenınclude yaptık.
                                .FirstOrDefaultAsync(p => p.Url == Url));
        }

        public IActionResult AddComment(int PostId, string Text, string Url)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);// NameIdentifier = id ye denk gelir
            var userName = User.FindFirstValue(ClaimTypes.Name);
            var avatar = User.FindFirstValue(ClaimTypes.UserData);

            var entity = new Comment
            {
                Text = Text,
                PostId = PostId,
                PublishedOn = DateTime.Now,
                UserId = int.Parse(userId ?? "")
            };
            _commentRepository.CreateComment(entity);


            // return Redirect("/posts/details/" + Url);
            return RedirectToRoute("post_details", new { url = Url });

        }

        [Authorize]// Login işlemi gerçekleştirilmeden CreatPost formu gelmemesi için yani login olmayan bu sayfaya ulaşamaz!!
        public IActionResult Create()
        {
            
            return View();
        }


        [HttpPost]
        [Authorize]
        public IActionResult Create(PostCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                _postRepository.CreatePost(

                    new Post
                    {
                        Title = model.Title,
                        Description = model.Description,
                        Content = model.Content,
                        Url = model.Url,
                        UserId = int.Parse(userId ?? ""),
                        PublishedOn = DateTime.Now,
                        Image = "1.jpg",
                        IsActive = false
                    }
                );
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> List()
        {
            var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
            var role = User.FindFirstValue(ClaimTypes.Role);
            var posts = _postRepository.Posts;

            if (string.IsNullOrEmpty(role))
            {
                posts = posts.Where(i => i.UserId == userId);
            }
            return View(await posts.ToListAsync());
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var post = _postRepository.Posts.FirstOrDefault(x => x.PostId == id);
            if (post == null)
            {
                return NotFound();
            }
            return View(new PostCreateViewModel
            {
                PostId = post.PostId,
                Title = post.Title,
                Description = post.Description,
                Content = post.Content,
                Url = post.Url,
                IsActive = post.IsActive
            });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(PostCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                var entityToUpdate = new Post
                {
                    PostId = model.PostId,
                    Title = model.Title,
                    Description = model.Description,
                    Content = model.Content,
                    Url = model.Url
                };

                if(User.FindFirstValue(ClaimTypes.Role)=="admin")
                {
                    entityToUpdate.IsActive = model.IsActive;
                }

                _postRepository.EditPost(entityToUpdate);
                return RedirectToAction("List");
            }
            return View(model);
        }
    }
}