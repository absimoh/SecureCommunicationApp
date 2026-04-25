namespace SecureCommunicationApp.Models
{
    public class GroupMember
    {
        public int GroupMemberId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ChatGroupId { get; set; }
        public ChatGroup ChatGroup { get; set; }
    }
}