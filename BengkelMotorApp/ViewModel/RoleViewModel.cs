using BengkelMotorApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BengkelMotorApp.ViewModel
{
    public class RoleViewModel
    {
        public IdentityRole Role { get; set; }
        public IEnumerable<UserIdentity> Members { get; set; }
        public IEnumerable<UserIdentity> NonMembers { get; set; }
    }

    public class RoleModification
    {
        [Required]
        public string RoleName { get; set; }

        public string RoleId { get; set; }

        public string[]? AddIds { get; set; }

        public string[]? DeleteIds { get; set; }
    }
}
