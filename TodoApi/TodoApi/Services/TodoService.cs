using TodoApi.Database;
using TodoApi.Database.Dto;
using TodoApi.Database.Enums;
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

        public List<Todo> GetAllTodosByDate(DateOnly date)
        {
            return _todoContext.Todos.ToList();
        }

        public List<Todo> GetActiveTodosByDate(DateOnly date)
        {
            return GetTodosByState(State.ACTIVE)
                .Where(todo => todo.Date == date)
                .ToList();
        }

        public Todo AddTodo(TodoDto dto)
        {
            var todo = Todo.CreateTodoFromDto(dto);

            _todoContext.Todos.Add(todo);
            _todoContext.SaveChanges();

            return todo;
        }


        public Todo RemoveTodoById(int id)
        {
            var todo = _todoContext.Todos.Find(id);

            if (todo != null)
            {
                _todoContext.Remove(todo);
                _todoContext.SaveChanges();
            }
            return todo;
        }

        private IQueryable<Todo> GetTodosByState(State state) => _todoContext.Todos.Where(todo => todo.State == state);

        public Todo UpdateTodo(TodoDto dto)
        {
            var todo = _todoContext.Todos.Find(dto.Id);

            if (todo != null)
            {
                todo.Title = dto.Title;
                todo.Description = dto.Description;
                todo.Date = dto.Date;

                _todoContext.SaveChanges();

                return todo;
            }
            return todo;
        }
    }
}
