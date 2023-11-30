using System.ComponentModel.DataAnnotations;

namespace CallAppUserManagementTask.cs.Models
{
    public class User
    {
        public int id { get; set; }
        public string username { get; set; } = "";
        public string password { get; set; } = "";
        [EmailAddress]
        public string email { get; set; } = "";
        public bool isActive { get; set; }
        public UserProfile? userProfile { get; set; }
    }
}
