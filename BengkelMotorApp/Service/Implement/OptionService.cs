using BengkelMotorApp.Areas.Identity.Data;
using BengkelMotorApp.ViewModel;

namespace BengkelMotorApp.Service.Implement
{
    public class OptionService : IOptionService
    {
        protected readonly ApplicationContext _context;

        public OptionService(ApplicationContext context)
        {
            _context = context;
        }

        public List<OptionViewModel> GetCustomer(string search)
        {
            var data = (from a in _context.Users
                        join b in _context.UserRoles on a.Id equals b.UserId
                        join c in _context.Roles on b.RoleId equals c.Id
                        where a.Fullname.Contains(search)
                            && c.Name == "Customer"
                        select new OptionViewModel
                                                                      {
                            Id = a.Id,
                            Label = a.Fullname,
                            Value = a.Id
                        }).ToList();
            return data;
        }
    }
}
