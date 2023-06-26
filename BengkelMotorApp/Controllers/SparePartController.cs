using BengkelMotorApp.Service;
using BengkelMotorApp.ViewModel;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace BengkelMotorApp.Controllers
{
    public class SparePartController : Controller
    {
        protected readonly ILogger<SparePartController> _logger;
        protected readonly ISparePartService _service;

        public SparePartController(ILogger<SparePartController> logger, ISparePartService service)
        {
            _logger = logger;
            _service = service;
        }

        public IActionResult Index()
        {
            var allData = _service.GetAll();
            var result = allData.Adapt<List<SparePartViewModel>>().ToList();
            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(SparePartViewModel viewModel)
        {
            try
            {
                _service.Create(viewModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Create Spare Part");
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var data = _service.Get(id).Result;
            var result = data.Adapt<SparePartViewModel>();
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(SparePartViewModel viewModel)
        {
            try
            {
                _service.Update(viewModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Edit Spare Part");
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Delete Spare Part");
                return View();
            }
        }
    }
}
