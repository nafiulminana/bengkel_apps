using BengkelMotorApp.ViewModel;

namespace BengkelMotorApp.Service
{
    public interface IOptionService
    {
        public List<OptionViewModel> GetCustomer(string search);
    }
}
