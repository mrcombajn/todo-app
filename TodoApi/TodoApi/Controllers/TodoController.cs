using Microsoft.AspNetCore.Mvc;
using TodoApi.Database;
using TodoApi.Database.Dto;
using TodoApi.Services;

namespace TodoApi.Controllers
{

    [Route("/todos")]
    [ApiController]
    public class TodoController : Controller
    {
        private readonly TodoService todoService;

        public TodoController(TodoContext context)
        {
            todoService = new TodoService(context);
        }

        [HttpGet]
        public ActionResult GetTodosByDate(DateOnly date)
        {
            return Ok(todoService.getTodosByDate(date));
        }

        [HttpPost]
        public ActionResult AddTodo([FromBody] TodoDto dto) => Ok(todoService.AddTodo(dto));

        [HttpDelete]
        public ActionResult RemoveTodoById(int id)
        {
            return todoService.RemoveTodoById(id) ? Ok() : BadRequest("There's no entity with given id.");
        }

        [HttpPut]
        public ActionResult UpdateTodo([FromBody] TodoDto dto)
        {
            return Ok(todoService.UpdateTodo(dto));
        }

        [HttpPut("{id}")]
        public ActionResult MarkTodoAsDone(int id) => todoService.UpdateTodoDone(id) ? Ok() : BadRequest("There's no entity with given id.");

    }
}
