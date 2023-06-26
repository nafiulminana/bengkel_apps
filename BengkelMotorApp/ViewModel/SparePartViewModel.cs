namespace BengkelMotorApp.ViewModel
{
    public class SparePartViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
