using Microsoft.EntityFrameworkCore;
using TodoApi.Database.Models;

namespace TodoApi.Database
{
    public class TodoContext : DbContext
    {

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {          
        }

        public DbSet<Todo> Todos => Set<Todo>();

    }
}
