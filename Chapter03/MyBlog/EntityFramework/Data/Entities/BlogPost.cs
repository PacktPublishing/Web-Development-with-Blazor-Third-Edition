using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities;

public class BlogPost
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Text { get; set; } = string.Empty;

    public DateTime PublishDate { get; set; }

    [ForeignKey("CategoryId")]
    public Category? Category { get; set; }
    public int? CategoryId { get; set; }

    public List<Tag> Tags { get; set; } = new();
}
