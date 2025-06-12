using System.ComponentModel.DataAnnotations;
using TodoApi.Database.Dto;
using TodoApi.Database.Enums;

namespace TodoApi.Database.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateOnly Date { get; set; }

        public DateTime CreatedDate { get; set; }

        public State State {  get; set; }

        public static Todo CreateTodoFromDto(TodoDto dto)
        {
            return new Todo()
            {
                Title = dto.Title,
                Description = dto.Description,
                Date = dto.Date,
                State = State.ACTIVE,
                CreatedDate = DateTime.UtcNow,
            };
        }
    }
}
