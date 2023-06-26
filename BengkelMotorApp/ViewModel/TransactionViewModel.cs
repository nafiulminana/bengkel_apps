namespace BengkelMotorApp.ViewModel
{
    public class TransactionViewModel
    {
        public string Id { get; set;}
        public string CustomerId { get; set;}
        public string CustomerName { get; set;}
        public string CustomerAddress { get; set;}
        public string TransactionNumber { get; set;}
        public DateTime TransactionDate { get; set;}
        public decimal TotalPrice { get; set;}
        public List<TransactionDetailViewModel> TransactionDetails { get; set;}
    }

    public class FilterTransactionViewModel
    {
        public string? StartDate { get; set;}
        public string? EndDate { get; set;}
    }

    public class ViewTransactionViewModel
    {
        public List<TransactionViewModel> transactionViewModels { get; set;}
        public FilterTransactionViewModel filterTransactionViewModel { get; set;}
    }
}
