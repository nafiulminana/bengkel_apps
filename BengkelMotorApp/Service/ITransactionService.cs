using BengkelMotorApp.Models;
using BengkelMotorApp.ViewModel;

namespace BengkelMotorApp.Service
{
    public interface ITransactionService
    {
        List<Transaction> GetAll(FilterTransactionViewModel viewModel);
        Task<Transaction> Get(int id);
        Task<Transaction> Create(TransactionViewModel viewModel);
        Task<Transaction> Update(TransactionViewModel viewModel);
        Task Delete(int id);
    }
}
