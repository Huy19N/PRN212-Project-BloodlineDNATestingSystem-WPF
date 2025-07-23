using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class BlogDAO
    {
        GeneCarePrnContext context = new GeneCarePrnContext();

        public List<Blog> GetAllBlogs()
        {
            return context.Blogs.ToList();
        }

        public Blog GetBlogById(int id)
        {
            return context.Blogs.FirstOrDefault(b => b.BlogId == id);
        }
        public bool AddBlog(Blog blog)
        {
            context.Blogs.Add(blog);
            return context.SaveChanges() > 0;
        }
        public bool DeleteBlog(int id)
        {
            context.Blogs.Remove(GetBlogById(id));
            return context.SaveChanges() > 0;
        }

        public bool UpdateBlog(Blog blog)
        {
            context.Blogs.Add(blog);
            return context.SaveChanges() > 0;
        }

        public List<Blog> GetBlogsByUserId(int userId)
        {
            return context.Blogs.Where(b => b.UserId == userId).ToList();
        }
    }
}
