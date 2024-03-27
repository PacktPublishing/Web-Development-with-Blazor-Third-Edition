using Data.Models;

namespace Data.Tests;

    public class BlogApiTestsUsingEntityFramework : IClassFixture<DataTestFixture>
    {
        private readonly DataTestFixture _fixture;

        public BlogApiTestsUsingEntityFramework(DataTestFixture fixture)
        {
            _fixture = fixture;
        }



    [Fact]
    public async Task BlogPostTests()
    {
        var cat = await _fixture.Api.SaveCategoryAsync(new Category() { Name = $"Category {DateTime.Now}" });
        var tag = await _fixture.Api.SaveTagAsync(new Tag() { Name = $"Tag {DateTime.Now}" });
        
        var post = await _fixture.Api.SaveBlogPostAsync(new BlogPost() { Title = $"Title {DateTime.Now}", Category = cat, Tags = new List<Tag> { tag! }, PublishDate = DateTime.Now, Text = "Text" });
        ArgumentException.ThrowIfNullOrEmpty(post!.Id);
        var comment = await _fixture.Api.SaveCommentAsync(new Comment { BlogPostId = post.Id, Date = DateTime.Now, Name = "Jimmy", Text = "Amazing post!" });
        var post2 = await _fixture.Api.GetBlogPostAsync(post.Id);
        var commments = await _fixture.Api.GetCommentsAsync(post.Id);
        Assert.NotNull(post2);
        Assert.Single(commments);

    }

    [Fact]
    public async Task CategoryTests()
    {
        var cat = await _fixture.Api.SaveCategoryAsync(new Category() { Name = $"Category {DateTime.Now}" });
        ArgumentException.ThrowIfNullOrEmpty(cat!.Id);
        var cat2 = await _fixture.Api.GetCategoryAsync(cat.Id);
        Assert.NotNull(cat2);
    }

    [Fact]
    public async Task TagTests()
    {
        var tag = await _fixture.Api.SaveTagAsync(new Tag() { Name = $"Tag {DateTime.Now}" });
        ArgumentException.ThrowIfNullOrEmpty(tag!.Id);
        var tag2 = await _fixture.Api.GetTagAsync(tag.Id);
        Assert.NotNull(tag2);
        Assert.Equal(tag.Name, tag2.Name);
        Assert.Equal(tag.Id, tag2.Id);
    }

    [Fact]
    public async Task BlogPostsTests()
    {

        //Make sure there are some posts (run it twice)
        await BlogPostTests();
        await BlogPostTests();

        var posts = await _fixture.Api.GetBlogPostsAsync(2,0);
    
        Assert.NotNull(posts);
        Assert.Equal(2, posts.Count);
    }
}