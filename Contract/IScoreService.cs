using Contract.Communications;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IScoreService
    {
        public Task<IEnumerable<Score>> RetriveTheListOfScores();
        public Task<ScoreResponce> ListScoresByUserId(string UserId);
        public Task<ScoreResponce> AddingScores(Score score);
        public Task<ScoreResponce> UpdateScoreBasedOnUserId(string UserId,Score score);
        public Task<ScoreResponce> DeleteScoreBasedOnUserId(string UserId);
    }
}
