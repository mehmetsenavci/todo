using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Timestamps
    {
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}