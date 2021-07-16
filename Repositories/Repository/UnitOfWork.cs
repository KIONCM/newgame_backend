using Entities.Context;
using Repositories.IRepository;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GamerDb Context;

        public UnitOfWork(GamerDb context)
        {
            Context = context;
        }
        public async Task CompleteAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
