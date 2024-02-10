namespace WebApplication4.Dto.User;

public class UserGetDtoInfo
{
    public int Id{ get; set; }
    public DateTime JoinDate { get; set; }
    public List<Entities.Book>? RentBooks{ get; set; }
    public string Name{ get; set; }
    public string Email { get; set; }
    public int RentedBookCount{ get; set; }
}