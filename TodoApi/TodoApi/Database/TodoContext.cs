using Microsoft.EntityFrameworkCore;

namespace TodoApi.Database
{
    public class TodoContext : DbContext
    {

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
            
        }

        public DbSet<Task> Tasks => Set<Task>();

    }
}
