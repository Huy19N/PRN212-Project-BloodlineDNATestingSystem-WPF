using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace DataAccessLayer;

public class BlogDAO
{
    public List<Blog> GetAllBlog()
    {
        using var context = new GeneCareContext();
        return context.Blogs.ToList();
    }
    public bool CreateBlog(Blog blog)
    {
        using var context = new GeneCareContext();
        if (blog == null) return false;
        using var transaction = context.Database.BeginTransaction();
        try
        {
            context.Blogs.Add(new Blog()
            {
                Content = blog.Content,
                CreatedAt = DateTime.Now,
                Title = blog.Title,
                UserId = blog.UserId,
            });
            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
    public bool UpdateBlog(Blog blog)
    {
        using var context = new GeneCareContext();
        if (blog == null) return false;
        var existingBlog = context.Blogs.Find(blog.BlogId);
        if (existingBlog == null) return false;

        using var transaction = context.Database.BeginTransaction();
        try
        {
            existingBlog.UserId = blog.UserId;
            existingBlog.Title = blog.Title;
            existingBlog.Content = blog.Content;
            existingBlog.CreatedAt = blog.CreatedAt;

            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
    public bool DeleteBlogById(int id)
    {
        using var context = new GeneCareContext();
        var blog = context.Blogs.Find(id);
        if (blog == null) return false;

        using var transaction = context.Database.BeginTransaction();
        try
        {
            context.Blogs.Remove(blog);
            context.SaveChanges();
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            return false;
        }
    }
}
