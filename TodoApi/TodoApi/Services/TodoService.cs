using TodoApi.Database;
using TodoApi.Database.Dto;
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

        public List<Todo> GetTodosByDate(DateOnly date)
        {
            return _todoContext.Todos.ToList();
        }

        public Todo AddTodo(TodoDto dto)
        {
            var todo = Todo.CreateTodoFromDto(dto);

            _todoContext.Todos.Add(todo);
            _todoContext.SaveChanges();

            return todo;
        }


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
