using Entities.Context;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class ScoreRepository : BaseRepository, IScoreRepository
    {
        public ScoreRepository(GamerDb context) : base(context)
        {
        }

        public async Task AddAsync(Score score)
        {
            await Context.Scores.AddAsync(score);
        }

        public void DeleteAsync(Score score)
        {
            Context.Scores.Remove(score);
        }

        public async Task<Score> FindByIdAsync(Guid Id)
        {
            return await Context.Scores
                .Include(u => u.User)
                .FirstOrDefaultAsync(u=>u.Id==Id);
        }

        public async Task<IEnumerable<Score>> ListAsync()
        {
            return await Context.Scores
                .Include(u=>u.User)
                .ToListAsync();
        }

        public void UpdateAsync(Score score)
        {
            Context.Scores.Update(score);
        }
    }
}
