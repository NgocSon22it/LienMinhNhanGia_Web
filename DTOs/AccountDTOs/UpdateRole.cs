using Obj_Common;
using System.ComponentModel.DataAnnotations;

namespace DTOs.AccountDTOs
{
    public class UpdateRole
    {
        [Required] public int AccountId { get; set; }
        public Role Role { get; set; }
    }
}
