using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Book_Management.Models;

public partial class Book
{

    public int Id { get; set; }

    [Required]
    public string? Title { get; set; }
    [Required]
    public string? Author { get; set; }
    [Required]
    public string? Isbn { get; set; }
    [Required]
    public DateTime? PublishedDate { get; set; }
    [Required]
    public string? Genre { get; set; }
}
