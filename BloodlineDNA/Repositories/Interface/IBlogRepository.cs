using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Repositories.Interface
{
    public interface IBlogRepository
    {
        public List<Blog> GetAllBlogs();
        public Blog GetBlogById(int id);
        public bool AddBlog(Blog blog);
        public bool DeleteBlog(int id);
        public bool UpdateBlog(Blog blog);
        public List<Blog> GetBlogsByUserId(int userId);
    }
}
