using BengkelMotorApp.Areas.Identity.Data;
using BengkelMotorApp.Models;
using BengkelMotorApp.Utils;
using BengkelMotorApp.ViewModel;
using Mapster;

namespace BengkelMotorApp.Service.Implement
{
    public class ServiceTypeService : IServiceTypeService
    {
        protected readonly ApplicationContext _context;

        public ServiceTypeService(ApplicationContext context)
        {
            _context = context;
        }

        public Task<ServiceType> Create(ServiceTypeViewModel viewModel)
        {
            var data = viewModel.Adapt<ServiceType>();
            data.CreatedAt = DateTime.Now;
            data.CreatedBy = ClaimUtil.GetUserId();
            data.IsActive = true; 
            _context.ServiceTypes.Add(data);
            _context.SaveChanges();
            return Task.FromResult(data);
        }

        public Task Delete(int id)
        {
            var data = _context.ServiceTypes.Find(id);
            if (data == null)
            {
                throw new Exception("Data not found");
            }
            _context.ServiceTypes.Remove(data);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<ServiceType> Get(int id)
        {
            var data = _context.ServiceTypes.Find(id);
            if (data == null)
            {
                throw new Exception("Data not found");
            }
            return Task.FromResult(data);
        }

        public List<ServiceType> GetAll()
        {
            var data = _context.ServiceTypes.ToList();
            return data;
        }

        public Task<ServiceType> Update(ServiceTypeViewModel viewModel)
        {
            var data = _context.ServiceTypes.Find(viewModel.Id);
            if (data == null)
            {
                throw new Exception("Data not found");
            }
            data = viewModel.Adapt(data);
            data.UpdatedAt = DateTime.Now;
            data.UpdatedBy = ClaimUtil.GetUserId();
            _context.SaveChanges();
            return Task.FromResult(data);
        }
    }
}
