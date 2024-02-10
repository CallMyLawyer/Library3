namespace WebApplication4.Dto.Book;

public class GetBookDto
{
    public int Id{ get; set; }
    public string Name{ get; set; }
    public string Category{ get; set; }
    public string Author{ get; set; }
    public DateTime PrintYear{ get; set; }
    public int RentedBookCount{ get; set; }
    public int Count{ get; set; }
    public DateTime RentBookDate{ get; set; }
}