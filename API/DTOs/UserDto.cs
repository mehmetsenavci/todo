using System;
using System.Collections.Generic;
using API.Entities;

namespace API.DTOs
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

    }
}