namespace WebApplication4.Dto.User;

public class UserRentBookDto
{
    public string Name{ get; set; }
    public string Email{ get; set; }
    public List<Entities.Book>? RentBooks{ get; set; } 
}