using Microsoft.AspNetCore.Mvc;
using WebApplication4.Dto.User;
using WebApplication4.Entities;

namespace WebApplication4.Controllers;

[Route("Api/Library")]
[ApiController]
public class UserController : Controller
{
    private readonly DataContext _context;

    public UserController(DataContext context)
    {
        _context = context;
    }

    [HttpPost("Set-User")]
    public void SetUser([FromQuery] UserPostDto dto)
    {
        User user = new();
        user.Name = dto.Name;
        user.Email = dto.Email;
        user.JoinDate = DateTime.Now;
        if (string.IsNullOrWhiteSpace(dto.Name))
        {
            throw new Exception("Mioooo!");
        }

        _context.Users.Add(user);
        _context.SaveChanges();
    }

    [HttpPatch("Update-User")]
    public void UpdateUser([FromQuery] string userName, [FromQuery] UserUpdateDto dto)
    {
        var user = _context.Users.First(_ => _.Name == userName);
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new Exception("Invalid User Name!");
        }

        user.Name = dto.Name;
        user.Email = dto.Email;
        _context.SaveChanges();
    }

    [HttpGet("Get-User")]
    public List<UserGetDto> GetUser(
        [FromQuery] string? userName = null,
        [FromQuery] string? userEmail = null)
    {
        var users = _context.Users.Select(_ => new UserGetDto()
        {
            Name = _.Name,
            Email = _.Email,
            Id = _.Id

        }).ToList();
        if (userName != null && userEmail != null)
        {
            var user = users.Where(_ => _.Name == userName && _.Email == userEmail).ToList();
            return user;
        }

        return users;
    }

    [HttpGet("User-Rented-Books")]
    public List<UserGetDtoInfo> GetUserInfo([FromQuery] int? id = null)
    {
        var users = _context.Users.Select(_ => new UserGetDtoInfo()
        {
            Id = _.Id,
         Name = _.Name,
         Email = _.Email,
         JoinDate = _.JoinDate,
         RentedBookCount = _.RentedBookCount,
         RentBooks = _.RentBooks
        }).ToList();
        if (id!=null)
        {
            var user = users.Where(_ => _.Id == id).ToList();
            return user;
        }
        return users;
    }

[HttpPatch("Rent-Book")]
    public void RentBook(
        [FromQuery]string userName,
        [FromQuery]string userEmail,
        [FromQuery]string bookName,
        [FromQuery]string bookAuthor)
    {
        var user = _context.Users.FirstOrDefault(_=>_.Name==userName);
        var email = _context.Users.FirstOrDefault(_ => _.Email == userEmail);
        if (user != null && email!=null)
        {
            var book = _context.Books.FirstOrDefault(_ => _.Name == bookName && _.Author==bookAuthor);
            if (book!=null && book.Count>=1 && user.RentedBookCount<4)
            {
                book.Count = book.Count - 1;
                user.RentedBookCount = user.RentedBookCount + 1;
                book.RentedBookCount = book.RentedBookCount = 1;
                book.RentBookDate= DateTime.Now;
                user.RentBooks.Add(book);
                
            }
        }
    }

    [HttpDelete("Delete-User")]
    public void DeleteUser([FromBody]string userName,[FromQuery] string email)
    {
        var user = _context.Users.First(_ => _.Name == userName);
        if (user==null)
        {
            throw new Exception("Invalid User Name!");
        }

        if (user.Email!=email)
        {
            throw new Exception("Invalid Email!");
        }

        _context.Users.Remove(user);
        _context.SaveChanges();
    }
}