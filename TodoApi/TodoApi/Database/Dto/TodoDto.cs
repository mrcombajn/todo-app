namespace TodoApi.Database.Dto
{
    public class TodoDto
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly DueTime { get; set; }

        public bool IsDone { get; set; }

    }
}
