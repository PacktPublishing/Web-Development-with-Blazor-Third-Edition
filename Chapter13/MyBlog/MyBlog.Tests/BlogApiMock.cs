using Data.Models;
using Data.Models.Interfaces;
using SharedComponents.Pages;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyBlog.Tests
{
    internal class BlogApiMock : IBlogApi
    {
        public async Task<BlogPost?> GetBlogPostAsync(string id)
        {
            BlogPost post = new()
            {
                Id = id,
                Text = $"This is a blog post no {id}",
                Title = $"Blogpost {id}",
                PublishDate = DateTime.Now,
                Category = await GetCategoryAsync("1"),
            };
            post.Tags.Add(await GetTagAsync("1"));
            post.Tags.Add(await GetTagAsync("2"));
            return post;
        }
        public Task<int> GetBlogPostCountAsync()
        {
            return Task.FromResult(10);
        }
        public async Task<List<BlogPost>?> GetBlogPostsAsync(int numberofposts, int startindex)
        {
            List<BlogPost> list = new();
            for (int a = 0; a < numberofposts; a++)
            {
                list.Add(await GetBlogPostAsync($"{startindex + a}"));
            }
            return list;
        }

        public async Task<List<Category>?> GetCategoriesAsync()
        {
            List<Category> list = new();
            for (int a = 0; a < 10; a++)
            {
                list.Add(await GetCategoryAsync($"{a}"));
            }
            return list;
        }
        public Task<Category?> GetCategoryAsync(string id)
        {
            return Task.FromResult(new Category() { Id = id, Name = $"Category {id}" });
        }

        public Task<Tag?> GetTagAsync(string id)
        {
            return Task.FromResult(new Tag() { Id = id, Name = $"Tag {id}" });
        }
        public async Task<List<Tag>?> GetTagsAsync()
        {
            List<Tag> list = new();
            for (int a = 0; a < 10; a++)
            {
                list.Add(await GetTagAsync($"{a}"));
            }
            return list;
        }

        public Task<BlogPost?> SaveBlogPostAsync(BlogPost item)
        {
            return Task.FromResult(item);
        }
        public Task<Category?> SaveCategoryAsync(Category item)
        {
            return Task.FromResult(item);
        }
        public Task<Tag?> SaveTagAsync(Tag item)
        {
            return Task.FromResult(item);
        }
        public Task DeleteBlogPostAsync(string id)
        {
            return Task.CompletedTask;
        }
        public Task DeleteCategoryAsync(string id)
        {
            return Task.CompletedTask;
        }
        public Task DeleteTagAsync(string id)
        {
            return Task.CompletedTask;
        }

        public Task<List<Comment>> GetCommentsAsync(string blogPostId)
        {
            var comments= new List<Comment>
            {
                new Comment { BlogPostId = blogPostId, Date = DateTime.Now, Id = "Comment1", Name = "Rocket Raccoon", Text = "I really want that arm!" }
            };
            return Task.FromResult(comments);
        }

        public Task<Comment?> SaveCommentAsync(Comment item)
        {
            return Task.FromResult(item);
        }

        public Task DeleteCommentAsync(string id)
        {
            return Task.CompletedTask;
        }
    }

}
