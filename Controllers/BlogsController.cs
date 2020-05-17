using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using efcore3_aspnetcore_demo.Models;

namespace efcore3_aspnetcore_demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly BlogContext db;

        public BlogsController(BlogContext db)
        {
            this.db = db;
        }

        // GET api/blogs
        [HttpGet("")]
        public ActionResult<IEnumerable<Blog>> GetBlogs()
        {
            return db.Blogs.ToList();
        }

        // GET api/blogs/add
        [HttpGet("add")]
        public ActionResult<Blog> AddNewBlog()
        {
            var blog = new Blog() {
               Url = "https://blog.miniasp.com",
               Rating = 5
            };
            db.Blogs.Add(blog);
            db.SaveChanges();

            return Created("/api/blog/" + blog.BlogId, blog);
        }

        // GET api/blogs/5
        [HttpGet("{id}")]
        public ActionResult<Blog> GetBlogById(int id)
        {
            return db.Blogs.Find(id);
        }

        // POST api/blogs
        [HttpPost("")]
        public void PostBlog(Blog value)
        {
            db.Blogs.Add(value);
            db.SaveChanges();
        }

        // PUT api/blogs/5
        [HttpPut("{id}")]
        public void PutBlog(int id, Blog value)
        {
            db.Blogs.Update(value);
            db.SaveChanges();
        }

        // DELETE api/blogs/5
        [HttpDelete("{id}")]
        public void DeleteBlogById(int id)
        {
            var blog = db.Blogs.Find(id);
            db.Blogs.Remove(blog);
            db.SaveChanges();
        }
    }
}