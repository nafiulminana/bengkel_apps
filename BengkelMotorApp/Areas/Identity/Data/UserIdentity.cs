using Microsoft.AspNetCore.Identity;

namespace BengkelMotorApp.Areas.Identity.Data
{
    public class UserIdentity : IdentityUser
    {
        [PersonalData]
        public string? Fullname { get; set; }
        [PersonalData]
        public string? Address { get; set; }
    }
}
