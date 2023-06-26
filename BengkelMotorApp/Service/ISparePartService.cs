using BengkelMotorApp.Models;
using BengkelMotorApp.ViewModel;

namespace BengkelMotorApp.Service
{
    public interface ISparePartService
    {
        List<SparePart> GetAll();
        Task<SparePart> Get(int id);
        Task<SparePart> Create(SparePartViewModel viewModel);
        Task<SparePart> Update(SparePartViewModel viewModel);
        Task Delete(int id);
    }
}
