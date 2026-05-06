using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SecureCommunicationApp.Models
{
    [Table("Messages", Schema = "Communication")]
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Message Content")]
        public string Content { get; set; } = string.Empty;

        [DataType(DataType.DateTime)]
        [Display(Name = "Sent Date")]
        public DateTime SentDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Display(Name = "Read Status")]
        public bool IsRead { get; set; } = false;

        [Required]
        public int SenderId { get; set; }

        [ForeignKey("SenderId")]
        [InverseProperty("SentMessages")]
        public User? Sender { get; set; }

        [Required]
        public int ReceiverId { get; set; }

        [ForeignKey("ReceiverId")]
        [InverseProperty("ReceivedMessages")]
        public User? Receiver { get; set; }
    }
}