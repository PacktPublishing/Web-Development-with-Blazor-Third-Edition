using System.ComponentModel.DataAnnotations;

namespace Data.Models;
public class BlogPost
{
    public string? Id { get; set; }
	[Required]
	[MinLength(5)]
	public string Title { get; set; } = string.Empty;
	[Required] 
	public string Text { get; set; } = string.Empty;
    public DateTime PublishDate { get; set; }
    public Category? Category { get; set; }
    public List<Tag> Tags { get; set; } = new();
}
