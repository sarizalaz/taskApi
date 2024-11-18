namespace lesson1.models
{
    public class Tasks
    {
        public int Id { get; set; }
        public string? Priority { get; set; }
        public DateTime? DueDate { get; set; }
        public string Status { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }

    }
}
