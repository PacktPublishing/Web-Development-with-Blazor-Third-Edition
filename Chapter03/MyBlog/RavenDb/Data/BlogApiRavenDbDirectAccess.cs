using Data.Models.Interfaces;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Data.Models;
using System.ComponentModel.Design;
using Raven.Client.Documents;


namespace Data;
public class BlogApiRavenDbDirectAccess : IBlogApi
{
    private readonly IDocumentStore _store;
    public BlogApiRavenDbDirectAccess(IDocumentStore store)
    {
        _store = store;
    }

    public async Task<int> GetBlogPostCountAsync()
    {
        using var session = _store.OpenAsyncSession();
        var count = await session.Query<BlogPost>().CountAsync();
        return count;
    }

    public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
    {
        using var session = _store.OpenAsyncSession();
        var posts = await session.Query<BlogPost>()
                                 .Skip(startindex)
                                 .Take(numberofposts)
                                 .ToListAsync();
        return posts;
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        using var session = _store.OpenAsyncSession();
        var categories = await session.Query<Category>().ToListAsync();
        return categories;
    }

    public async Task<List<Tag>> GetTagsAsync()
    {
        using var session = _store.OpenAsyncSession();
        var tags = await session.Query<Tag>().ToListAsync();
        return tags;
    }

    public async Task<List<Comment>> GetCommentsAsync(string blogPostId)
    {
        using var session = _store.OpenAsyncSession();
        var comments = await session.Query<Comment>().Where(c => c.BlogPostId == blogPostId).ToListAsync();
        return comments;
    }

    public async Task<BlogPost?> GetBlogPostAsync(string id)
    {
        using var session = _store.OpenAsyncSession();
        var post = await session.LoadAsync<BlogPost>(id);
        return post;
    }

    public async Task<Category?> GetCategoryAsync(string id)
    {
        using var session = _store.OpenAsyncSession();
        var category = await session.LoadAsync<Category>(id);
        return category;
    }

    public async Task<Tag?> GetTagAsync(string id)
    {
        using var session = _store.OpenAsyncSession();
        var tag = await session.LoadAsync<Tag>(id);
        return tag;
    }

    public async Task<BlogPost?> SaveBlogPostAsync(BlogPost item)
    {
        using var session = _store.OpenAsyncSession();
        await session.StoreAsync(item);
        await session.SaveChangesAsync();
        return item;
    }

    public async Task<Category?> SaveCategoryAsync(Category item)
    {
        using var session = _store.OpenAsyncSession();
        await session.StoreAsync(item);
        await session.SaveChangesAsync();
        return item;
    }

    public async Task<Tag?> SaveTagAsync(Tag item)
    {
        using var session = _store.OpenAsyncSession();
        await session.StoreAsync(item);
        await session.SaveChangesAsync();
        return item;
    }

    public async Task<Comment?> SaveCommentAsync(Comment item)
    {
        using var session = _store.OpenAsyncSession();
        await session.StoreAsync(item);
        await session.SaveChangesAsync();
        return item;
    }

    public async Task DeleteBlogPostAsync(string id)
    {
        using var session = _store.OpenAsyncSession();
        session.Delete(id);
        await session.SaveChangesAsync();
    }

    public async Task DeleteCategoryAsync(string id)
    {
        using var session = _store.OpenAsyncSession();
        session.Delete(id);
        await session.SaveChangesAsync();
    }

    public async Task DeleteTagAsync(string id)
    {
        using var session = _store.OpenAsyncSession();
        session.Delete(id);
        await session.SaveChangesAsync();
    }

    public async Task DeleteCommentAsync(string id)
    {
        using var session = _store.OpenAsyncSession();
        session.Delete(id);
        await session.SaveChangesAsync();
    }
}
