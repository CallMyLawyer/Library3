using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Dto.Book;

public class BookDto
{
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Author { get; set; }
        public DateTime PrintYear { get; set; }
}