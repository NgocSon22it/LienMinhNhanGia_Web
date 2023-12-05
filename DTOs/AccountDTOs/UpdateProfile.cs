using Obj_Common;
using System.ComponentModel.DataAnnotations;

namespace DTOs.AccountDTOs
{
    public class UpdateProfile
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Avatar { get; set; }
    }
}
