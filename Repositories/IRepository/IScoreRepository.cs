using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.IRepository
{
    public interface IScoreRepository
    {
        public Task<IEnumerable<Score>> ListAsync();
        public Task<Score>FindByUserIdAsync(string UserId);
        public Task<Score>AddAsync(Score score);
        public void UpdateAsync(Score score);
        public void DeleteAsync(Score score);

    }
}
