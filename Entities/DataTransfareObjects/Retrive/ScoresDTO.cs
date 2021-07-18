using System;

namespace Entities.DataTransfareObjects.Retrive
{
    public class ScoresDTO
    {
        public Guid Id { get; set; }
        public int Scores { get; set; }
        public UserDTO User { get; set; }
    }
}