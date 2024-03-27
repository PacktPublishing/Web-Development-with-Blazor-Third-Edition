namespace Data.Models.Interfaces;
public interface IBlogApi
{
    Task<int> GetBlogPostCountAsync();
    Task<List<BlogPost>> GetBlogPostsAsync(int numberofposts, int startindex);
    Task<List<Category>> GetCategoriesAsync();
    Task<List<Tag>> GetTagsAsync();
    Task<List<Comment>> GetCommentsAsync(string blogPostId);
    Task<BlogPost?> GetBlogPostAsync(string id);
    Task<Category?> GetCategoryAsync(string id);
    Task<Tag?> GetTagAsync(string id);
    Task<BlogPost?> SaveBlogPostAsync(BlogPost item);
    Task<Category?> SaveCategoryAsync(Category item);
    Task<Tag?> SaveTagAsync(Tag item);
    Task<Comment?> SaveCommentAsync(Comment item);
    Task DeleteBlogPostAsync(string id);
    Task DeleteCategoryAsync(string id);
    Task DeleteTagAsync(string id);
    Task DeleteCommentAsync(string id);
}
