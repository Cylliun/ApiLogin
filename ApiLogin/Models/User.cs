﻿using Microsoft.AspNetCore.Identity;

namespace ApiLogin.Models
{
    public class User : IdentityUser
    {
        public int Id {  get; set; }
        public  string UserName { get; set; }
        public  string Email { get; set; }
        public  string PasswordHash { get; set; }

    }
}
