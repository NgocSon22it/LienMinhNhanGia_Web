using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs.AccountDTOs
{
    public class Forgot
    {
        [Required] public string Username { get; set; }
        public string Password { get; set; }

       
        public string ConfirmPassword { get; set; }
    }
}
