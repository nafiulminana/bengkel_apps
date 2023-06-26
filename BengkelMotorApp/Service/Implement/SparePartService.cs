using BengkelMotorApp.Areas.Identity.Data;
using BengkelMotorApp.Models;
using BengkelMotorApp.Utils;
using BengkelMotorApp.ViewModel;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace BengkelMotorApp.Service.Implement
{
    public class SparePartService : ISparePartService
    {
        protected readonly ApplicationContext _context;

        public SparePartService(ApplicationContext context)
        {
            _context = context;
        }

        public Task<SparePart> Create(SparePartViewModel viewModel)
        {
            var data = viewModel.Adapt<SparePart>();
            data.CreatedAt = DateTime.Now;
            data.CreatedBy = ClaimUtil.GetUserId();
            _context.SpareParts.Add(data);
            _context.SaveChanges();
            return Task.FromResult(data);
        }

        public Task Delete(int id)
        {
            var data = _context.SpareParts.Find(id);
            if (data == null)
            {
                throw new Exception("Data not found");
            }
            _context.SpareParts.Remove(data);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<SparePart> Get(int id)
        {
            var data = _context.SpareParts.Find(id);
            if (data == null)
            {
                throw new Exception("Data not found");
            }
            return Task.FromResult(data);
        }

        public List<SparePart> GetAll()
        {
            var data = _context.SpareParts.ToList();
            return data;
        }

        public Task<SparePart> Update(SparePartViewModel viewModel)
        {
            var data = _context.SpareParts.Find(viewModel.Id);
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
