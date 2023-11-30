namespace CallAppUserManagementTask.cs.Models.DTOs
{
    public class PostsAndCommentDTO
    {
        public int userid { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public string comments{ get; set; }
    }
}
