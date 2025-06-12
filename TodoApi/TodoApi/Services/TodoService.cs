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

        public List<Todo> GetTodosByDate(DateTime dateTime)
        {
            return _todoContext.Todos.ToList();
        }

        public void AddTodo(Todo todo) => _todoContext.Todos.Update(todo);
  
        public void RemoveTodoById(int id)
        {
            var todo = _todoContext.Todos.Find(id);

            if (todo != null)
            {
                _todoContext.Remove(todo);
                _todoContext.SaveChanges();
            }
        }
    }
}
