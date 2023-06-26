using BengkelMotorApp.Service;
using BengkelMotorApp.ViewModel;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;

namespace BengkelMotorApp.Controllers
{
    public class TransactionController : Controller
    {
        protected readonly ILogger<TransactionController> _logger;
        protected readonly ITransactionService _service;
        protected readonly IOptionService _optionService;

        public TransactionController(ILogger<TransactionController> logger, ITransactionService service, IOptionService option)
        {
            _logger = logger;
            _service = service;
            _optionService = option;
        }

        public IActionResult Index(FilterTransactionViewModel viewModel)
        {
            var filter = new FilterTransactionViewModel
            {
                StartDate = viewModel.StartDate ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).ToString("yyyy-MM-dd"),
                EndDate = viewModel.EndDate ?? new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month)).ToString("yyyy-MM-dd")
            };
            var allData = _service.GetAll(filter);
            var result = allData.Adapt<List<TransactionViewModel>>().ToList();
            
            ViewTransactionViewModel viewTransactionViewModel = new ViewTransactionViewModel
            {
                transactionViewModels = result,
                filterTransactionViewModel = filter
            };

            return View(viewTransactionViewModel);
        }

        public IActionResult Create()
        {
            ViewBag.Customers = _optionService.GetCustomer("");
            return View();
        }

        [HttpPost]
        public IActionResult Create(TransactionViewModel viewModel)
        {
            try
            {
                _service.Create(viewModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Create Transaction");
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var data = _service.Get(id).Result;
            var result = data.Adapt<TransactionViewModel>();
            return View(result);
        }

        [HttpPost]
        public IActionResult Edit(TransactionViewModel viewModel)
        {
            try
            {
                _service.Update(viewModel);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error Edit Transaction");
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
                _logger.LogError(ex, "Error Delete Transaction");
                return View();
            }
        }


    }
}
