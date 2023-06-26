using BengkelMotorApp.Models;
using BengkelMotorApp.ViewModel;

namespace BengkelMotorApp.Service
{
    public interface IServiceTypeService
    {
        List<ServiceType> GetAll();
        Task<ServiceType> Get(int id);
        Task<ServiceType> Create(ServiceTypeViewModel viewModel);
        Task<ServiceType> Update(ServiceTypeViewModel viewModel);
        Task Delete(int id);
    }

}
