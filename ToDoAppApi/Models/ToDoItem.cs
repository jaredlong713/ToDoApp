namespace ToDoAppApi.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public string? Note { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
