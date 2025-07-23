using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using Repositories;
using Repositories.Interface;

namespace Services
{
    public class BlogService : Interface.IBlogService
    {
        IBlogRepository blogRepository;

        public BlogService()
        {
            blogRepository = new BlogRepository();
        }
        public bool AddBlog(Blog blog)
        {
            return blogRepository.AddBlog(blog);
        }

        public bool DeleteBlog(int id)
        {
            return blogRepository.DeleteBlog(id);
        }

        public List<Blog> GetAllBlogs()
        {
            return blogRepository.GetAllBlogs();
        }

        public Blog GetBlogById(int id)
        {
            return blogRepository.GetBlogById(id);
        }

        public List<Blog> GetBlogsByUserId(int userId)
        {
            return blogRepository.GetBlogsByUserId(userId);
        }

        public bool UpdateBlog(Blog blog)
        {
            return blogRepository.UpdateBlog(blog);
        }
    }
}
