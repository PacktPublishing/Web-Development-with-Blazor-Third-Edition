namespace Data.Models;

public class Comment
{
    public string? Id { get; set; }
    public required string BlogPostId { get; set; }
    public DateTime Date { get; set; }
    public string Text { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}
