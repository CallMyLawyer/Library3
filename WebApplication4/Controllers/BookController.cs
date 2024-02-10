using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;
using WebApplication4.Dto.Book;
using WebApplication4.Entities;

namespace WebApplication4.Controllers;
[Route("Api/Library")]
[ApiController]
public class BookController : Controller
{
    
    private readonly DataContext _context;

    public BookController(DataContext context)
    {
        _context = context;
    }

    [HttpPost("Set-Book")]
    public void SetBook([FromBody] BookSetDto dto)
    {
        var book = new Book();
        book.Name = dto.Name;
        book.Author = dto.Author;
        book.Category = dto.Category;
        book.PrintYear = dto.PrintYear;
        book.Count = dto.Count;
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    [HttpPatch("Update-Book")]
    public void UpdateBook([FromQuery] string bookName ,[FromQuery] BookUpdateDto dto)
    {
        var book = _context.Books.First(_ => _.Name == bookName);
        book.Name = dto.Name;
        book.Author = dto.Author;
        book.Category = dto.Category;
        book.PrintYear= dto.PrintYear;
        _context.Books.Add(book);
        _context.SaveChanges();
    }

    [HttpGet("Get-Book")]
    public List<GetBookDto>GetBookByName(
        [FromQuery] string? bookName = null,
        [FromQuery] string? authorName = null)
    {
            var books = _context.Books.Select(_=> new GetBookDto()
            {
                Count = _.Count,
                RentedBookCount = _.RentedBookCount,
                RentBookDate = _.RentBookDate,
                Author = _.Author,
                Category = _.Category,
                Id = _.Id,
                Name = _.Name,
                PrintYear = _.PrintYear
            }).ToList();
            if (bookName!=null&&authorName!=null)
            {
                var book = books.Where(_ => _.Name == bookName && _.Author == authorName).ToList();
                return book;
            }
            if (bookName!=null)
            {
                var book = books.Where(_ => _.Name == bookName).ToList();
                return book;
            }

            if (authorName!=null)
            {
                var book = books.Where(_ => _.Author == authorName).ToList();
                return book;
            }
            return books;
    }

    [HttpDelete("Delete-Book")]
    public void DeleteBook(string bookName)
    {
        var book = _context.Books.First(_ => _.Name == bookName);
        _context.Books.Remove(book);
    }
}