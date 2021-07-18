using Entities.Models;
using GamersAndFansAPI.Domain.Services.Communications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Communications
{
    public class ScoreResponce : BaseResponce
    {
        public Score Score{ get; set; }
        public ScoreResponce(bool success, string message,Score score) : base(success, message)
        {
            Score = score;
        }

        public ScoreResponce(Score score):this(true,string.Empty,score)
        {

        }

        public ScoreResponce(string message):this(false,message,null)
        {

        }
    }
}
