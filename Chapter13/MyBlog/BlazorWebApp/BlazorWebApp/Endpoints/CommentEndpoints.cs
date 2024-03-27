using Data.Models;
using Data.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace BlazorWebApp.Endpoints;
public static class CommentEndpoints
{
    public static void MapCommentApi(this WebApplication app)
    {
        app.MapGet("/api/Comments/{*blogPostid}",
        async (IBlogApi api, string blogPostid) =>
        {
            return Results.Ok(await api.GetCommentsAsync(blogPostid));
        });
        app.MapDelete("/api/Comments/{*id}",
        async (IBlogApi api, string id) =>
        {
            await api.DeleteCommentAsync(id);
            return Results.Ok();
        }).RequireAuthorization();
        app.MapPut("/api/Comments",
        async (IBlogApi api, [FromBody] Comment item) =>
        {
            return Results.Ok(await api.SaveCommentAsync(item));
        }).RequireAuthorization();
    }
}
