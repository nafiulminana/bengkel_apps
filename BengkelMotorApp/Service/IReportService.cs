using BengkelMotorApp.ViewModel;

namespace BengkelMotorApp.Service
{
    public interface IReportService
    {
        public Task<List<ReportViewModel>> GetByFilter(FilterReportViewModel filter);
        public Task<ReportViewModel> GetById(int id);
    }
}
