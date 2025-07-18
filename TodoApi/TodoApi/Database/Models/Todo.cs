﻿using System.ComponentModel.DataAnnotations;
using TodoApi.Database.Dto;

namespace TodoApi.Database.Models
{
    public class Todo
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public DateTime Date { get; set; }

        public bool IsDone { get; set; } = false;

        public static Todo CreateTodoFromDto(TodoDto dto)
        {
            return new Todo()
            {
                Title = dto.Title,
                Description = dto.Description,
                Date = dto.Date,
                IsDone = dto.IsDone,
            };
        }
    }
}
