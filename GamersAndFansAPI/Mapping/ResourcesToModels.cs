using AutoMapper;
using Entities.DataTransfareObjects;
using Entities.Models;

namespace GamersAndFansAPI.Mapping
{
    public class ResourcesToModels:Profile
    {
        public ResourcesToModels()
        {
            CreateMap<RegisterUserDTO, User>();
            CreateMap<LoginDTO, User>();
            CreateMap<SaveScoresDTO, Score>();
            CreateMap<UpdateOrDeleteScoresDTO, Score>();
        }
    }
}
