using BengkelMotorApp.Areas.Identity.Data;
using BengkelMotorApp.Models;
using BengkelMotorApp.Utils;
using BengkelMotorApp.ViewModel;
using Mapster;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text;

namespace BengkelMotorApp.Service.Implement
{
    public class TransactionService : ITransactionService
    {
        protected readonly ApplicationContext _context;

        public TransactionService(ApplicationContext context)
        {
            _context = context;
        }

        public Task<Transaction> Create(TransactionViewModel viewModel)
        {
            var data = viewModel.Adapt<Transaction>();
            data.CreatedAt = DateTime.Now;
            data.CreatedBy = ClaimUtil.GetUserId();
            _context.Transactions.Add(data);
            _context.SaveChanges();
            return Task.FromResult(data);
        }

        public Task Delete(int id)
        {
            var data = _context.Transactions.Find(id);
            if (data == null)
            {
                throw new Exception("Data not found");
            }
            _context.Transactions.Remove(data);
            _context.SaveChanges();
            return Task.CompletedTask;
        }

        public Task<Transaction> Get(int id)
        {
            var data = _context.Transactions.Find(id);
            if (data == null)
            {
                throw new Exception("Data not found");
            }
            return Task.FromResult(data);
        }

        public List<Transaction> GetAll(FilterTransactionViewModel viewModel)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter("@StartDate", string.Format("{0:yyyy-MM-dd}", viewModel.StartDate))
                , new SqlParameter("@EndDate", string.Format("{0:yyyy-MM-dd}", viewModel.EndDate))
            };

            StringBuilder query = new StringBuilder();
            query.Append("exec").Append(" ");
            query.Append("SpGetAllTransaction").Append(" ");
            query.Append("@StartDate").Append(",").Append(" ");
            query.Append("@EndDate").Append(" ");

            SqlParameter[] parametersArray = parameters.ToArray();
            List<Transaction> result = _context.Transactions.FromSqlRaw(query.ToString(), parametersArray).ToList();
            return result;
        }

        public Task<Transaction> Update(TransactionViewModel viewModel)
        {
            var data = viewModel.Adapt<Transaction>();
            data.UpdatedAt = DateTime.Now;
            data.UpdatedBy = ClaimUtil.GetUserId();
            _context.Transactions.Update(data);
            _context.SaveChanges();
            return Task.FromResult(data);
        }
    }
}
