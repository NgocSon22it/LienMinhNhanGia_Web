using Obj_Common;
using System.ComponentModel.DataAnnotations;

namespace DTOs.AccountDTOs
{
    public class Register
    {
        [Required] public string Name { get; set; }
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }

        [Required]
        [Compare(nameof(Password))] 
        public string ConfirmPassword { get; set; }

        public Role Role { get; set; } = Role.Player;
        public string Avatar { get; set; } = "/img/user.png";
    }
}
