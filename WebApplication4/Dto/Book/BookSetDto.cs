using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Dto.Book;

public class BookSetDto
{
    public int Id{ get; set; }
    [Required]
    public string Name{ get; set; }
    [Required]
    public string Category { get; set; }
    [Required]
    public string Author { get; set; }
    public DateTime PrintYear { get; set; }
    public int Count{ get; set; }
}