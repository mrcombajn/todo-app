using System.ComponentModel.DataAnnotations;

namespace TodoApi.Database.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
