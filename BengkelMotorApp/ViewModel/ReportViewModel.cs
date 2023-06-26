namespace BengkelMotorApp.ViewModel
{
    public class ReportViewModel
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }

        public string TransactionNumber { get; set; }
        public DateTime? TransactionDate { get; set; }
        public decimal TotalPrice { get; set; }
        public List<ReportDetailViewModel> TransactionDetails { get; set; }
    }

    public class FilterReportViewModel
    {
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }

    public class ReportDetailViewModel
    {
        public int Id { get; set; }
        public string SparePartName { get; set; }
        public string ServiceTypeName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }

    }
}
