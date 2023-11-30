namespace CallAppUserManagementTask.cs.Models.DTOs
{
    public class TodoDTO
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Completed { get; set; }
    }
}
