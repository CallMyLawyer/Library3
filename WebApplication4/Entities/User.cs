namespace WebApplication4.Entities;

public class User
{
    public int Id{ get; set; }
    public string Name{ get; set; }
    public string Email{ get; set; }
    public DateTime JoinDate { get; set; }
    public List<Book>? RentBooks{ get; set; }
    public int RentedBookCount{ get; set; }
}