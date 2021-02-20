using System;
using System.ComponentModel.DataAnnotations;

namespace API.Entities
{
    public class Todo : Timestamps
    {
        [Key]
        public Guid TodoId { get; set; }
        [Required]
        public string Desription { get; set; }
        [Required]
        public bool IsDone { get; set; }

        

    }
}