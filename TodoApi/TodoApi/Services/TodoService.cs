using TodoApi.Database;
using TodoApi.Database.Models;

namespace TodoApi.Services
{
    public class TodoService
    {
        private readonly TodoContext _todoContext;

        public TodoService(TodoContext todoContext)
        {
            _todoContext = todoContext;
        }

        public List<Todo> GetTodos()
        {
            return _todoContext.Todos.ToList();
        }

        public void AddTodo(Todo todo)
        {
            _todoContext.Todos.Add(todo);
        }
    }
}
