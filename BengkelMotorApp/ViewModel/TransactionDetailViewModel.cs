namespace BengkelMotorApp.ViewModel
{
    public class TransactionDetailViewModel
    {
        public string TransactionId { get; set;}
        public string SparePartId { get; set;}
        public string ServiceTypeId { get; set;}
        public int Quantity { get; set;}
        public decimal Price { get; set;}
        public decimal TotalPrice { get; set;}

        public SparePartViewModel SparePart { get; set;}
        public ServiceTypeViewModel ServiceType { get; set;}
    }
}
