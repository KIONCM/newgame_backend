using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransfareObjects
{
    public class UpdateOrDeleteScoresDTO
    {
        public Guid Id { get; set; }
        public int Scores { get; set; }
        public string UserId { get; set; }
    }
}
