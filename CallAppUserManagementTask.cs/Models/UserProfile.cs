using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CallAppUserManagementTask.cs.Models
{
    public class UserProfile
    {
        [Key]
        public int id { get; set; }
        public int userid { get; set; }
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = "";
        [MaxLength(11)]
        public string personalNumber { get; set; } = "";
        [JsonIgnore]
        public User? user { get; set; } = null!;
    }
}
