using System;
using System.ComponentModel.DataAnnotations;

namespace Mission07.Models
{
    public class LoginModel
    {
        // makes a username and password required when calling the
        // login model
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

        // also includes the Url to return to
        public string ReturnUrl { get; set; }
    }
}
