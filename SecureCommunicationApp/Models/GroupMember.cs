using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecureCommunicationApp.Models
{
    [Table("GroupMembers", Schema = "Communication")]
    public class GroupMember
    {
        [Key]
        public int GroupMemberId { get; set; }

        [Required]
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public User? User { get; set; }

        [Required]
        public int ChatGroupId { get; set; }

        [ForeignKey("ChatGroupId")]
        public ChatGroup? ChatGroup { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Joined At")]
        public DateTime JoinedAt { get; set; } = DateTime.UtcNow;

        [Display(Name = "Group Role")]
        public GroupRole Role { get; set; } = GroupRole.Member;
    }
}