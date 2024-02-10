namespace WebApplication4.Dto.User;

public class UserRentBooksDto
{
    public List<Entities.Book>? RentBooks{ get; set; }
    public string Name{ get; set; }
    public string Email { get; set; }
    public int RentedBookCount{ get; set; }
}