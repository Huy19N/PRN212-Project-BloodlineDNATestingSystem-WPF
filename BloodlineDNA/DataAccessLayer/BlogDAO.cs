using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class BlogDAO
    {
        private readonly GeneCareContext _context;
        public BlogDAO()
        {
            _context = new GeneCareContext();
        }
        public BlogDAO(GeneCareContext context)
        {
            _context = context;
        }
        
        public async Task<Blog?> GetBlogByIdAsync(int blogId)
        {
            try
            {
                return await _context.Blogs.FindAsync(blogId);
            }

            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving the blog.", ex);
            }
        }

        public async Task<List<Blog>> GetAllBlogsAsync()
        {
            try
            {
                return await _context.Blogs.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving all blog.", ex);
            }
        }

        public async Task<Blog> CreateBlogAsync(Blog blog)
        {
            try
            {
                _context.Blogs.Add(blog);
                await _context.SaveChangesAsync();
                return blog;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating the blog.", ex);
            }
        }

        public async Task<Blog> UpdateBlogAsync(Blog blog)
        {
            try
            {
                _context.Entry(blog).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return blog;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while updating the blog.", ex);
            }
        }

        public async Task<bool> DeleteBlogAsync(int blogId)
        {
            try
            {
                var blog = await _context.Blogs.FindAsync(blogId);
                if (blog == null)
                {
                    return false; // Blog not found
                }
                _context.Blogs.Remove(blog);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while deleting the blog.", ex);
            }
        }
    }
}
