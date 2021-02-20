using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Context
{
    public class TodoContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }

        public TodoContext(DbContextOptions<TodoContext> contextOptions)
            : base(contextOptions)
        {
        }
        
    }
}