using Microsoft.EntityFrameworkCore;

namespace TodoApi.Database
{
    public class TodoContext : DbContext
    {

        public TodoContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Task> Tasks => Set<Task>();

    }
}
