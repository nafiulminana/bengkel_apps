using BengkelMotorApp.Areas.Identity.Data;
using BengkelMotorApp.ViewModel;

namespace BengkelMotorApp.Service.Implement
{
    public class ReportService : IReportService
    {
        protected readonly ApplicationContext _context;

        public ReportService(ApplicationContext context)
        {
            _context = context;
        }

        public Task<List<ReportViewModel>> GetByFilter(FilterReportViewModel filter)
        {
            var allSparePart = _context.SpareParts.ToList();
            var allServiceType = _context.ServiceTypes.ToList();
            var allTransaction = _context.Transactions.ToList();
            var allTransactionDetail = _context.TransactionDetails.ToList();
            var allUser = _context.Users.ToList();

            var data = (from a in allTransaction
                        join e in allUser on a.UserId equals e.Id

                        select new ReportViewModel
                        {
                            Id = a.Id,
                            CustomerName = e.Fullname,
                            CustomerAddress = e.Address,
                            TotalPrice = a.TotalPrice,
                            TransactionNumber = a.TransactionNumber,
                            TransactionDate = a.TransactionDate,
                            TransactionDetails = (from f in allTransactionDetail
                                                  join g in allSparePart on f.SparePartId equals g.Id
                                                  join h in allServiceType on f.ServiceTypeId equals h.Id
                                                  where f.TransactionId == a.Id
                                                  select new ReportDetailViewModel
                                                  {
                                                      SparePartName = g.Name,
                                                      ServiceTypeName = h.Name,
                                                      Quantity = f.Quantity,
                                                      Price = f.Price,
                                                      TotalPrice = f.TotalPrice
                                                  }).ToList()
                        }).ToList();

            return Task.FromResult(data);
        }

        public Task<ReportViewModel> GetById(int id)
        {
            var allSparePart = _context.SpareParts.ToList();
            var allServiceType = _context.ServiceTypes.ToList();
            var allTransaction = _context.Transactions.ToList();
            var allTransactionDetail = _context.TransactionDetails.ToList();
            var allUser = _context.Users.ToList();

            var data = (from a in allTransaction
                        join e in allUser on a.UserId equals e.Id
                        where a.Id == id
                        select new ReportViewModel
                        {
                            Id = a.Id,
                            CustomerName = e.Fullname,
                            CustomerAddress = e.Address,
                            TotalPrice = a.TotalPrice,
                            TransactionNumber = a.TransactionNumber,
                            TransactionDate = a.TransactionDate,
                            TransactionDetails = (from f in allTransactionDetail
                                                  join g in allSparePart on f.SparePartId equals g.Id
                                                  join h in allServiceType on f.ServiceTypeId equals h.Id
                                                  where f.TransactionId == a.Id
                                                  select new ReportDetailViewModel
                                                  {
                                                      SparePartName = g.Name,
                                                      ServiceTypeName = h.Name,
                                                      Quantity = f.Quantity,
                                                      Price = f.Price,
                                                      TotalPrice = f.TotalPrice
                                                  }).ToList()
                        }).FirstOrDefault();

            return Task.FromResult(data); 
        }
    }
}
