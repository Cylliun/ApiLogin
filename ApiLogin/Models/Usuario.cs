﻿namespace ApiLogin.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string SenhaHash { get; set; }

    }
}
