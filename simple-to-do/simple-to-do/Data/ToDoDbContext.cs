using Microsoft.EntityFrameworkCore;

namespace simple_to_do.Models
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
        }

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Users> Users { get; set; }
    }
}
