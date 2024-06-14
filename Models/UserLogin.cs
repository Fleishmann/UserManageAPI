﻿using System.ComponentModel.DataAnnotations;

namespace UserManageAPI.Models
{
    public class UserLogin
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}