using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
