using System.ComponentModel.DataAnnotations;

namespace SecureCommunicationApp.Models
{
    public class ChatGroup
    {
        public int ChatGroupId { get; set; }

        [Required]
        public string GroupName { get; set; }

        public ICollection<GroupMember> Members { get; set; }
    }
}