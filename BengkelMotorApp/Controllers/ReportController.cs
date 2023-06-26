using BengkelMotorApp.Service;
using BengkelMotorApp.Service.Implement;
using BengkelMotorApp.ViewModel;
using Mapster;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using OfficeOpenXml;

namespace BengkelMotorApp.Controllers
{
    public class ReportController : Controller
    {
        protected readonly ILogger<ReportController> _logger;
        protected readonly IReportService _service;
        protected readonly IViewEngine _viewEngine;

        public ReportController(ILogger<ReportController> logger, IReportService service, IViewEngine viewEngine)
        {
            _logger = logger;
            _service = service;
            _viewEngine = viewEngine;
        }

        public IActionResult Index(FilterReportViewModel viewModel)
        {
            var allData = _service.GetByFilter(viewModel).Result;
            return View(allData);
        }

        public IActionResult Detail(int id)
        {
            var data = _service.GetById(id).Result;
            return View(data);
        }

        public IActionResult ExportExcel(FilterReportViewModel viewModel)
        {
            var allData = _service.GetByFilter(viewModel).Result;
            var result = allData.Adapt<List<ReportViewModel>>().ToList();
            var stream = new MemoryStream();
            using (var package = new ExcelPackage(stream))
            {
                var worksheet = package.Workbook.Worksheets.Add("Report");
                worksheet.Cells["A1"].Value = "Title";
                worksheet.Cells["B1"].Value = "Author";
                worksheet.Cells["C1"].Value = "Total Transaction";
                worksheet.Cells["D1"].Value = "Total Book";
                worksheet.Cells["E1"].Value = "Total User";
                worksheet.Cells["F1"].Value = "Total Income";
                worksheet.Cells["A2"].LoadFromCollection(result);
                package.Save();
            }
            stream.Position = 0;
            string excelName = $"Report-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.xlsx";
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelName);
        }

        public IActionResult ExportPdf(FilterReportViewModel viewModel)
        {
            var render = new IronPdf.HtmlToPdf();
            var allData = _service.GetByFilter(viewModel).Result;
            var result = allData.Adapt<List<ReportViewModel>>().ToList();
            var html = this.RenderViewAsync("ExportPdf", result).Result;
            var pdf = render.RenderHtmlAsPdf(html);
            var output = pdf.BinaryData;
            string pdfName = $"Report-{DateTime.Now.ToString("yyyyMMddHHmmssfff")}.pdf";
            return File(output, "application/pdf", pdfName);
        }

        private async Task<string> RenderViewAsync(string viewName, object model)
        {
            ViewData.Model = model;
            using (var writer = new StringWriter())
            {
                var viewResult = _viewEngine.FindView(ControllerContext, viewName, false);
                if (viewResult.View == null)
                {
                    throw new ArgumentNullException($"{viewName} does not match any available view");
                }
                var viewContext = new ViewContext(
                                       ControllerContext,
                                       viewResult.View,
                                       ViewData,
                                       TempData,
                                       writer,
                                       new HtmlHelperOptions()
                                                                                                                                                     );
                await viewResult.View.RenderAsync(viewContext);
                return writer.GetStringBuilder().ToString();
            }
        }
    }
}
