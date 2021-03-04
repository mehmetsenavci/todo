using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is Timestamps && (
                    e.State == EntityState.Added ||
                    e.State == EntityState.Modified
                ));

            foreach (var item in entries)
            {
                if (item.State == EntityState.Added)
                {
                    ((Timestamps)item.Entity).CreatedAt = DateTime.Now;
                }
                else if (item.State == EntityState.Modified)
                {
                    ((Timestamps)item.Entity).UpdatedAt = DateTime.Now;
                }
            }

            return (await base.SaveChangesAsync(true, cancellationToken));
        }

    }
}