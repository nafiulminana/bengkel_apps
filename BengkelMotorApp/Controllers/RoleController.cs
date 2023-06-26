using BengkelMotorApp.Areas.Identity.Data;
using BengkelMotorApp.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BengkelMotorApp.Controllers
{
    public class RoleController : Controller
    {
        protected RoleManager<IdentityRole> _roleManager;
        private UserManager<UserIdentity> _userManager;

        public RoleController(RoleManager<IdentityRole> roleManager, UserManager<UserIdentity> user)
        {
            _roleManager = roleManager;
            _userManager = user;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<IdentityRole> roles = _roleManager.Roles;
            List<RoleViewModel> result = new List<RoleViewModel>();
            foreach (var role in roles)
            {
                var users = await _userManager.GetUsersInRoleAsync(role.Name);
                RoleViewModel item = new RoleViewModel
                {
                    Role = role,
                    Members = users.ToList()
                };
                result.Add(item);
            }
            return View(result);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create([Required] string name)
        {
            if (ModelState.IsValid)
            {
                IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(name));
                if (result.Succeeded)
                    return RedirectToAction("Index");
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                IdentityResult result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                    return RedirectToAction("Index");
            }
            else
                ModelState.AddModelError("", "No role found");
            return View("Index", _roleManager.Roles);
        }

        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await _roleManager.FindByIdAsync(id);
            List<UserIdentity> members = new List<UserIdentity>();
            List<UserIdentity> nonMembers = new List<UserIdentity>();
            foreach (UserIdentity user in _userManager.Users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
            }
            return View(new RoleViewModel
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            });
        }

        [HttpPost]
        public async Task<IActionResult> Update(RoleModification model)
        {
            IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (string userId in model.AddIds ?? new string[] { })
                {
                    UserIdentity user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.AddToRoleAsync(user, model.RoleName);
                    }
                }
                foreach (string userId in model.DeleteIds ?? new string[] { })
                {
                    UserIdentity user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await _userManager.RemoveFromRoleAsync(user, model.RoleName);
                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction(nameof(Index));
            else
                return await Update(model.RoleId);
        }
    }
}
