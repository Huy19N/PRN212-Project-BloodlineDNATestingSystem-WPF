using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class BlogRepository : Interface.IBlogRepository
    {
        BlogDAO blogDAO = new BlogDAO();
        public bool AddBlog(Blog blog)
        {
            return blogDAO.AddBlog(blog);
        }

        public bool DeleteBlog(int id)
        {
            return blogDAO.DeleteBlog(id);
        }

        public List<Blog> GetAllBlogs()
        {
            return blogDAO.GetAllBlogs();
        }

        public Blog GetBlogById(int id)
        {
            return blogDAO.GetBlogById(id);
        }

        public List<Blog> GetBlogsByUserId(int userId)
        {
            return blogDAO.GetBlogsByUserId(userId);
        }

        public bool UpdateBlog(Blog blog)
        {
            return blogDAO.UpdateBlog(blog);
        }
    }
}
