namespace TodoApi.Database.Dto
{
    public class TodoDto
    {
        public int? Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public bool IsDone { get; set; }

    }
}
