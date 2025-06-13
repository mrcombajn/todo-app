using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoApi.Database;
using TodoApi.Database.Dto;
using TodoApi.Database.Models;
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
            return Ok(todoService.GetActiveTodosByDate(date));
        }

        [HttpPost]
        public ActionResult AddTodo(TodoDto dto) => Ok(todoService.AddTodo(dto));

        [HttpDelete]
        public ActionResult RemoveTodoById(int id)
        {
            return Ok(todoService.RemoveTodoById(id));
        }

        /*
        [HttpPut]
        [app]
        public void UpdateTodo()
        {

        }*/
    }
}
