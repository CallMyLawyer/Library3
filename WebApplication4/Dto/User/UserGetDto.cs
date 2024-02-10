using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Dto.User;

public class UserGetDto
{
        [Key]
        public int Id{ get; set; }
        public string Name{ get; set; }
        public string Email { get; set; }
}