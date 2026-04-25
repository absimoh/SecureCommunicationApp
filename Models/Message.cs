using System.ComponentModel.DataAnnotations;

namespace SecureCommunicationApp.Models
{
   public class Message
{
    public int MessageId { get; set; }

    public string Content { get; set; } = string.Empty;

    public DateTime SentDate { get; set; }

    public int SenderId { get; set; }
    public User Sender { get; set; } = null!;

    public int ReceiverId { get; set; }
    public User Receiver { get; set; } = null!;
}
}
