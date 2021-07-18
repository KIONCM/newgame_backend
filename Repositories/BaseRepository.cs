using Entities.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class BaseRepository
    {
        protected readonly GamerDb Context;
        public BaseRepository(GamerDb context)
        {
            Context = context;
        }
    }
}
