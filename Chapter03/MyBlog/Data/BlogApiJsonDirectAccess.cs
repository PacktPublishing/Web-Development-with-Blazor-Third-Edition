using Data.Models.Interfaces;
using Microsoft.Extensions.Options;
using System.Text.Json;
using Data.Models;
using System.ComponentModel.Design;

namespace Data;
public class BlogApiJsonDirectAccess : IBlogApi
{
    BlogApiJsonDirectAccessSetting _settings;
    public BlogApiJsonDirectAccess(IOptions<BlogApiJsonDirectAccessSetting> option)
    {
        _settings = option.Value;

        ManageDataPaths();
    }
    private void ManageDataPaths()
    {
        CreateDirectoryIfNotExists(_settings.DataPath);
        CreateDirectoryIfNotExists($@"{_settings.DataPath}\{_settings.BlogPostsFolder}");
        CreateDirectoryIfNotExists($@"{_settings.DataPath}\{_settings.CategoriesFolder}");
        CreateDirectoryIfNotExists($@"{_settings.DataPath}\{_settings.TagsFolder}");
        CreateDirectoryIfNotExists($@"{_settings.DataPath}\{_settings.CommentsFolder}");
    }

    private static void CreateDirectoryIfNotExists(string path)
    {
        if (!Directory.Exists(path))
        {
            Directory.CreateDirectory(path);
        }
    }

    private async Task<List<T>> LoadAsync<T>(string folder)
    {
        var list = new List<T>();
        foreach (var f in Directory.GetFiles($@"{_settings.DataPath}\{folder}"))
        {
            var json = await File.ReadAllTextAsync(f);
            var blogPost = JsonSerializer.Deserialize<T>(json);
            if (blogPost is not null)
            {
                list.Add(blogPost);
            }
        }

        return list;
    }

    private async Task SaveAsync<T>(string folder, string filename, T item)
    {
        var filepath = $@"{_settings.DataPath}\{folder}\{filename}.json";
        await File.WriteAllTextAsync(filepath, JsonSerializer.Serialize<T>(item));
    }

    private Task DeleteAsync(string folder, string filename)
    {
        var filepath = $@"{_settings.DataPath}\{folder}\{filename}.json";
        if (File.Exists(filepath))
        {
            File.Delete(filepath);
        }
        return Task.CompletedTask;
    }


    public async Task<int> GetBlogPostCountAsync()
    {
        var list = await LoadAsync<BlogPost>(_settings.BlogPostsFolder);
        return list.Count;
    }

    public async Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex)
    {
        var list = await LoadAsync<BlogPost>(_settings.BlogPostsFolder);
        return list.Skip(startindex).Take(numberofposts).ToList();
    }

    public async Task<List<Category>> GetCategoriesAsync()
    {
        return await LoadAsync<Category>(_settings.CategoriesFolder);
    }

    public async Task<Category?> GetCategoryAsync(string id)
    {
        var list = await LoadAsync<Category>(_settings.CategoriesFolder);
        return list.FirstOrDefault(c => c.Id == id);
    }


    public async Task<List<Tag>> GetTagsAsync()
    {
        return await LoadAsync<Tag>(_settings.TagsFolder);
    }

    public async Task<Tag?> GetTagAsync(string id)
    {
        var list = await LoadAsync<Tag>(_settings.TagsFolder);
        return list.FirstOrDefault(t => t.Id == id);
    }

    public async Task<BlogPost?> GetBlogPostAsync(string id)
    {
        var list = await LoadAsync<BlogPost>(_settings.BlogPostsFolder);
        return list.FirstOrDefault(bp => bp.Id == id);
    }

    public async Task<List<Comment>> GetCommentsAsync(string blogPostId)
    {
        var list = await LoadAsync<Comment>(_settings.CommentsFolder);
        return list.Where(t => t.BlogPostId == blogPostId).ToList();
    }

    public async Task<BlogPost?> SaveBlogPostAsync(BlogPost item)
    {
        item.Id ??= Guid.NewGuid().ToString();
        await SaveAsync(_settings.BlogPostsFolder, item.Id, item);
        return item;
    }

    public async Task<Category?> SaveCategoryAsync(Category item)
    {
        item.Id ??= Guid.NewGuid().ToString();
        await SaveAsync(_settings.CategoriesFolder, item.Id, item);
        return item;
    }

    public async Task<Tag?> SaveTagAsync(Tag item)
    {
        item.Id ??= Guid.NewGuid().ToString();
        await SaveAsync(_settings.TagsFolder, item.Id, item);
        return item;
    }
    public async Task<Comment?> SaveCommentAsync(Comment item)
    {
        item.Id ??= Guid.NewGuid().ToString();
        await SaveAsync(_settings.CommentsFolder, item.Id, item);
        return item;
    }


    public async Task DeleteBlogPostAsync(string id)
    {
        await DeleteAsync(_settings.BlogPostsFolder, id);
        
        var comments = await GetCommentsAsync(id);
        foreach (var comment in comments)
        {
            if (comment.Id != null)
            {
                await DeleteAsync(_settings.CommentsFolder, comment.Id);
            }
        }
    }

    public async Task DeleteCategoryAsync(string id)
    {
        await DeleteAsync(_settings.CategoriesFolder, id);
    }

    public async Task DeleteTagAsync(string id)
    {
        await DeleteAsync(_settings.TagsFolder, id);
    }

    public async Task DeleteCommentAsync(string id)
    {
        await DeleteAsync(_settings.CommentsFolder, id);
    }


}
