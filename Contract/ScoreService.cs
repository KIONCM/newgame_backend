﻿using Contract.Communications;
using Entities.Models;
using Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class ScoreService : IScoreService
    {
        private readonly IScoreRepository ScoreRepository;
        private readonly IUnitOfWork UnitOfWork;
        private readonly ILoggerManager Logger;

        public ScoreService(IScoreRepository scoreRepository,IUnitOfWork unitOfWork,ILoggerManager logger)
        {
            ScoreRepository = scoreRepository;
            UnitOfWork = unitOfWork;
            Logger = logger;
        }
        public async Task<ScoreResponce> AddingScores(Score score)
        {
            try
            {
                await ScoreRepository.AddAsync(score);
                await UnitOfWork.CompleteAsync();
                Logger.LogInfo("Score Added Successfully .");
                return new ScoreResponce(score);
            }
            catch(Exception exception)
            {
                Logger.LogError($"An error has accured when trying to insert new score : {exception}");
                return new ScoreResponce("An error has accured when trying to insert new score");
            }
        }

        public async Task<ScoreResponce> DeleteScore(Score score)
        {
            
            var ExistingScore = await ScoreRepository.FindByUserIdAsync(score.UserId);
            if (ExistingScore != null)
                Logger.LogInfo("UserId in Scores not Found!");

            try
            {
                ScoreRepository.DeleteAsync(ExistingScore);
                await UnitOfWork.CompleteAsync();
                return new ScoreResponce($"The score with info :{ExistingScore} /n Has been deleted successfully.");

            }
            catch(Exception exception)
            {
                Logger.LogError($"An error has accured when trying to deleting score : {exception}");
                return new ScoreResponce("An error has accured when trying to delete existing score .. Please try later!");
            }
            
        }

        public async Task<ScoreResponce> ListScoresByUserId(string UserId)
        {
            var score = await ScoreRepository.FindByUserIdAsync(UserId);
            if (score != null)
                return new ScoreResponce(score);
            return new ScoreResponce("User id in scores not found!");

        }

        public async Task<IEnumerable<Score>> RetriveTheListOfScores()
        {
            return await ScoreRepository.ListAsync();
        }

        public async Task<ScoreResponce> UpdateScoreBasedOnUserId(string UserId, Score score)
        {
            var ExistingScore = await ScoreRepository.FindByUserIdAsync(UserId);
            if (ExistingScore == null)
                Logger.LogInfo("Score not found ! ");
            ExistingScore.Scores = score.Scores;
            try
            {
                ScoreRepository.UpdateAsync(ExistingScore);
                await UnitOfWork.CompleteAsync();
                return new ScoreResponce(ExistingScore);
            }
            catch(Exception exception)
            {
                Logger.LogError($"An Error has accured when trying to update a value of scores :{exception}");
                return new ScoreResponce("An Error has accured when trying to update a value of scores");
            }
        }
    }
}