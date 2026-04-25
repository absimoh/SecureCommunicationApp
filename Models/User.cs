using System.ComponentModel.DataAnnotations;

namespace SecureCommunicationApp.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required]
        public string Email { get; set; }

        public UserRole Role { get; set; }

        public ICollection<GroupMember> GroupMembers { get; set; }
    }
}