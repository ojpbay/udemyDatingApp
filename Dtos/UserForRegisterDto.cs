using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace udemyDatingApp.Dtos
{
    public class UserForRegisterDto
    {
        [Required]
        [StringLength(25, MinimumLength = 3, ErrorMessage = "You must specify a username between 3 and 20 characters in length")]
        public string Username { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters in length")]
        public string Password { get; set; }
    }
}
