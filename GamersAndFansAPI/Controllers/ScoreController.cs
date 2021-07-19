using API.Extentions;
using AutoMapper;
using Contract;
using Entities.DataTransfareObjects;
using Entities.DataTransfareObjects.Retrive;
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScoreController : ControllerBase
    {
        private readonly IScoreService ScoreService;
        private readonly IMapper Mapper;
        public ScoreController(IScoreService scoreService,IMapper mapper)
        {
            ScoreService = scoreService;
            Mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ScoresDTO>> ListAsync()
        {
            var Scores = await ScoreService.RetriveTheListOfScores();
            var resources = Mapper.Map<IEnumerable<Score>, IEnumerable<ScoresDTO>>(Scores);
            return resources;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult>GetByUserIdAsync(string UserId)
        {
            var resault = await ScoreService.ListScoresByUserId(UserId);
            if (!resault.Success)
                return BadRequest(resault.Message);
            var resource = Mapper.Map<Score, ScoresDTO>(resault.Score);
            return Ok(resource);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveScoresDTO saveScoresDTO)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var score = Mapper.Map<SaveScoresDTO, Score>(saveScoresDTO);
            var resault = await ScoreService.AddingScores(score);
            if (!resault.Success)
                return BadRequest(resault.Message);
            var resource = Mapper.Map<Score, ScoresDTO>(resault.Score);
            return Ok(resource);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(string id,[FromBody]SaveScoresDTO saveScoresDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());
            var score = Mapper.Map<SaveScoresDTO, Score>(saveScoresDTO);
            var resault = await ScoreService.UpdateScoreBasedOnUserId(id, score);
            if (!resault.Success)
                return NotFound(resault.Message);
            var resource = Mapper.Map<Score, ScoresDTO>(resault.Score);
            return Ok(resource);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult>DeleteAsync(Score score)
        {
            var resault = await ScoreService.DeleteScore(score);
            if (!resault.Success)
                return BadRequest(resault.Message);
            var resource = Mapper.Map<Score, ScoresDTO>(resault.Score);
            return Ok(resource);
        }
    }
}
