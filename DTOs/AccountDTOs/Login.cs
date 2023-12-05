using System.ComponentModel.DataAnnotations;

namespace DTOs.AccountDTOs
{
    public class Login
    {
        [Required]
        public string Username { get; set; }


        [Required]
        public string Password { get; set; }
    }
}
