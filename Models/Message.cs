using System.ComponentModel.DataAnnotations;

namespace SecureCommunicationApp.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime SentDate { get; set; } = DateTime.Now;

        // Sender
        public int SenderId { get; set; }
        public User Sender { get; set; }

        // Receiver
        public int ReceiverId { get; set; }
        public User Receiver { get; set; }
    }
}