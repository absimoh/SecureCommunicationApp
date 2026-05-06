using System.ComponentModel.DataAnnotations;

namespace SecureCommunicationApp.Models
{
    public enum UserRole
    {
        [Display(Name = "Administrator")]
        Admin,

        [Display(Name = "Regular User")]
        User,

        [Display(Name = "Moderator")]
        Moderator
    }
}