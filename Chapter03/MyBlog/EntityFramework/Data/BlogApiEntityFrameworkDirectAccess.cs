using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Entities;
using Data.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace Data;

public class BlogApiEntityFrameworkDirectAccess : IBlogApi
{
    IDbContextFactory<BlogDbContext> factory;
    public BlogApiEntityFrameworkDirectAccess(IDbContextFactory<BlogDbContext> factory)
    {
        this.factory = factory;
    }

    public async Task<Data.Models.BlogPost?> GetBlogPostAsync(string id)
    {
        using var context = factory.CreateDbContext();
        //Convert id to an int
        if (int.TryParse(id, out int intid))
        {
            var item = await context.BlogPosts.Include(p => p.Category).Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == intid);
            if (item != null)
            {
                return ConvertBlogPostToDto(item);
            }
        }
        return null;

    }


    private static Data.Models.Tag ConvertTagToDto(Tag item)
    {
        return new Data.Models.Tag() { Id = item.Id.ToString(), Name = item.Name };
    }

    private static Data.Models.Comment ConvertCommentToDto(Comment item)
    {
        return new Data.Models.Comment() { Id = item.Id.ToString(), Text = item.Text, Date = item.Date, BlogPostId = item.BlogPostId.ToString(), Name = item.Name };
    }

    private static Data.Models.Category? ConvertCategoryToDto(Category? item)
    {
        if (item == null)
        {
            return null;
        }
        return new Data.Models.Category() { Id = item.Id.ToString(), Name = item.Name };
    }

    private static Data.Models.BlogPost ConvertBlogPostToDto(BlogPost item)
    {
        Data.Models.Category? category = null;
        if (item.Category != null)
        {
            category = new Data.Models.Category() { Id = item.Category.Id.ToString(), Name = item.Category.Name };
        }
        return new Data.Models.BlogPost()
        {
            Id = item.Id.ToString(),
            Title = item.Title,
            Text = item.Text,
            PublishDate = item.PublishDate,
            Category = category,
            Tags = item.Tags.Select(t => new Data.Models.Tag() { Id = t.Id.ToString(), Name = t.Name }).ToList()
        };
    }

    public async Task<List<Data.Models.BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
    {
        using var context = factory.CreateDbContext();
        return await context.BlogPosts.OrderByDescending(p => p.PublishDate).Skip(startindex).Take(numberofposts).Select(p => ConvertBlogPostToDto(p)).ToListAsync();
    }

    public async Task<int> GetBlogPostCountAsync()
    {
        using var context = factory.CreateDbContext();
        return await context.BlogPosts.CountAsync();
    }


    public async Task<List<Data.Models.Category>> GetCategoriesAsync()
    {
        using var context = factory.CreateDbContext();
        return await context.Categories.Select(c => ConvertCategoryToDto(c)!).ToListAsync();
    }

    public async Task<Data.Models.Category?> GetCategoryAsync(string id)
    {
        using var context = factory.CreateDbContext();
        return ConvertCategoryToDto(await context.Categories.FirstOrDefaultAsync(c => c.Id == Convert.ToInt32(id)));

    }

    public async Task<Data.Models.Tag?> GetTagAsync(string id)
    {
        using var context = factory.CreateDbContext();
        var item = await context.Tags.FirstOrDefaultAsync(t => t.Id == Convert.ToInt32(id) );
        if (item != null)
        {
            return ConvertTagToDto(item);
        }
        return null;
    }

    public async Task<List<Data.Models.Tag>> GetTagsAsync()
    {
        using var context = factory.CreateDbContext();
        return await context.Tags.Select(t => ConvertTagToDto(t)).ToListAsync();
    }

    private async Task DeleteItemAsync<T>(T item)
    {
        ArgumentNullException.ThrowIfNull(item, nameof(item));
        using var context = factory.CreateDbContext();
        context.Remove(item);
        await context.SaveChangesAsync();
    }

    public async Task DeleteBlogPostAsync(string id)
    {
        var item=GetBlogPostAsync(id);
        await DeleteItemAsync(item);
    }

    public async Task DeleteCategoryAsync(string id)
    {
        var item=GetCategoryAsync(id);
        await DeleteItemAsync(item);
    }

    public async Task DeleteTagAsync(string id)
    {
        var item=GetTagAsync(id);
        await DeleteItemAsync(item);
    }

    public async Task DeleteCommentAsync(string id)
    {
        var item=GetCommentAsync(id);
        await DeleteItemAsync(item);
    }

    public async Task<Data.Models.Comment?> GetCommentAsync(string id)
    {
        using var context = factory.CreateDbContext();
        var item = await context.Comments.FirstOrDefaultAsync(t => t.Id == Convert.ToInt32(id));
        if (item != null)
        {
            return ConvertCommentToDto(item);
        }
        return null;
    }

    private async Task<Data.Models.BlogPost> SaveItem(Data.Models.BlogPost item)
    {
        using var context = factory.CreateDbContext();
        if (item.Id == null)
        {
            var newitem = new BlogPost()
            {
                Title = item.Title,
                Text = item.Text,
                PublishDate = item.PublishDate,
                CategoryId = item.Category == null ? null : int.Parse(item.Category.Id!),
            };

            foreach (var tag in item.Tags)
            {
                var t = await context.Tags.FirstOrDefaultAsync(t => t.Id == Convert.ToInt32(tag.Id));
                if (t != null)
                {
                    newitem.Tags.Add(t);
                }
            }

            context.Add(newitem);
            await context.SaveChangesAsync();
            item.Id = newitem.Id.ToString();
            return item;
        }
        else
        {
            var existingitem = await context.BlogPosts.Include(p => p.Category).Include(p => p.Tags).FirstOrDefaultAsync(p => p.Id == Convert.ToInt32(item.Id));
            if (existingitem != null)
            {
                existingitem.Title = item.Title;
                existingitem.Text = item.Text;
                existingitem.PublishDate = item.PublishDate;
                existingitem.CategoryId = item.Category == null ? null : int.Parse(item.Category.Id!);
                
                existingitem.Tags.Clear();
                foreach (var tag in item.Tags)
                {
                    var t = await context.Tags.FirstOrDefaultAsync(t => t.Id == Convert.ToInt32(tag.Id));
                    if (t != null)
                    {
                        existingitem.Tags.Add(t);
                    }
                }
                await context.SaveChangesAsync();
                return item;
            }
        }
        return item;
    }

    private async Task<Data.Models.Tag> SaveItem(Data.Models.Tag item)
    {
        using var context = factory.CreateDbContext();
        if (item.Id == null)
        {
            var newitem = new Tag()
            {
                Name = item.Name,
            };
            context.Add(newitem);
            await context.SaveChangesAsync();
            item.Id = newitem.Id.ToString();
            return item;
        }
        else
        {
            var existingitem = await context.Tags.FirstOrDefaultAsync(p => p.Id == Convert.ToInt32(item.Id));
            if (existingitem != null)
            {
                existingitem.Name = item.Name;
                await context.SaveChangesAsync();
                return item;
            }
        }
        return item;
    }
    private async Task<Data.Models.Category> SaveItem(Data.Models.Category item)
    {
        using var context = factory.CreateDbContext();
        if (item.Id == null)
        {
            var newitem = new Category()
            {
                Name = item.Name,
            };
            context.Add(newitem);
            await context.SaveChangesAsync();
            item.Id = newitem.Id.ToString();
            return item;
        }
        else
        {
            var existingitem = await context.Categories.FirstOrDefaultAsync(p => p.Id == Convert.ToInt32(item.Id));
            if (existingitem != null)
            {
                existingitem.Name = item.Name;
                await context.SaveChangesAsync();
                return item;
            }
        }
        return item;
    }

    private async Task<Data.Models.Comment> SaveItem(Data.Models.Comment item)
    {
        using var context = factory.CreateDbContext();
        if (item.Id == null)
        {
            var newitem = new Comment()
            {
                BlogPostId = int.Parse(item.BlogPostId),
                Text = item.Text,
                Date = item.Date,
                Name = item.Name
            };
            context.Add(newitem);
            await context.SaveChangesAsync();
            item.Id = newitem.Id.ToString();
            return item;
        }
        else
        {
            var existingitem = await context.Comments.FirstOrDefaultAsync(p => p.Id == Convert.ToInt32(item.Id));
            if (existingitem != null)
            {
                existingitem.Text = item.Text;
                await context.SaveChangesAsync();
                return item;
            }
        }
        return item;
    }


    public async Task<Data.Models.BlogPost?> SaveBlogPostAsync(Data.Models.BlogPost item)
    {
        return await SaveItem(item);
    }

    public async Task<Data.Models.Category?> SaveCategoryAsync(Data.Models.Category item)
    {
        return await SaveItem(item);
    }

    public async Task<Data.Models.Tag?> SaveTagAsync(Data.Models.Tag item)
    {
        return await SaveItem(item);
    }

    public async Task<Data.Models.Comment?> SaveCommentAsync(Data.Models.Comment item)
    {
        return await SaveItem(item);
    }

    public async Task<List<Models.Comment>> GetCommentsAsync(string blogPostId)
    {
        using var context = factory.CreateDbContext();
        int id=Convert.ToInt32(blogPostId);
        return await context.Comments.Where(c=>c.BlogPostId==id).Select(t => ConvertCommentToDto(t)).ToListAsync();
    }
}