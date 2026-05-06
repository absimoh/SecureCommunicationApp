using System.ComponentModel.DataAnnotations;

namespace SecureCommunicationApp.Models
{
    public enum GroupRole
    {
        [Display(Name = "Member")]
        Member,

        [Display(Name = "Administrator")]
        Admin,

        [Display(Name = "Group Owner")]
        Owner
    }
}