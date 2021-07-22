﻿using Contract.Communications;
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
        public Task<ScoreResponce> ListScoresById(Guid Id);
        public Task<ScoreResponce> AddingScores(Score score);
        public Task<ScoreResponce> UpdateAsync(Score score);
        public Task<ScoreResponce> DeleteAsync(Score score);
    }
}
