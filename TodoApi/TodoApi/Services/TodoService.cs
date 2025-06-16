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

        public List<Todo> getTodosByDate(DateTime date)
        {
            return _todoContext.Todos
                .Where(todo =>
                    todo.Date.Year == date.Year && 
                    todo.Date.Month == date.Month &&
                    todo.Date.Day == date.Day)
                .ToList();
        }

        public Todo AddTodo(TodoDto dto)
        {
            var todo = Todo.CreateTodoFromDto(dto);

            _todoContext.Todos.Add(todo);
            _todoContext.SaveChanges();

            return todo;
        }


        public bool RemoveTodoById(int id)
        {
            var todo = _todoContext.Todos.Find(id);

            if (todo != null)
            {
                _todoContext.Remove(todo);
                _todoContext.SaveChanges();

                return true;
            }
            return false;
        }

        public TodoDto UpdateTodo(TodoDto dto)
        {
            var todo = _todoContext.Todos.Find(dto.Id);

            if (todo != null)
            {
                todo.Title = dto.Title;
                todo.Description = dto.Description;
                todo.Date = dto.Date;

                _todoContext.SaveChanges();

                return dto;
            }

            return dto;
        }

        public bool UpdateTodoDone(int id)
        {
            var todo = _todoContext.Todos.Find(id);

            if (todo != null)
            {
                todo.IsDone = !todo.IsDone;

                _todoContext.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
