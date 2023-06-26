using BengkelMotorApp.Service;
using BengkelMotorApp.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BengkelMotorApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class OptionController : Controller
    {
        protected readonly ILogger<OptionController> _logger;
        protected readonly IOptionService _service;

        public OptionController(ILogger<OptionController> logger, IOptionService service)
        {
            _logger = logger;
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public List<OptionViewModel> GetCustomer(string search)
        {
            var data = _service.GetCustomer(search);
            return data;
        }
    }
}
