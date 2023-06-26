using BengkelMotorApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BengkelMotorApp.Utils
{
    public static class ClaimUtil
    {

        // get user id from claim
        public static string GetUserId()
        {
            // get http context
            var context = new HttpContextAccessor().HttpContext;
            // get user manager
            var _userManager = (UserManager<UserIdentity>)context.RequestServices.GetService(typeof(UserManager<UserIdentity>));
            // get user id
            return _userManager.GetUserId(context.User);
        }

        // get role name from claim
        public static string GetRoleName()
        {
            // get http context
            var context = new HttpContextAccessor().HttpContext;
            var _userManager = (UserManager<UserIdentity>)context.RequestServices.GetService(typeof(UserManager<UserIdentity>));
            return _userManager.GetRolesAsync(_userManager.GetUserAsync(context.User).Result).Result[0];
        }


    }
}
