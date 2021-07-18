using AutoMapper;
using Entities.DataTransfareObjects.Retrive;
using Entities.Models;

namespace GamersAndFansAPI.Mapping
{
    public class ModelsToResource:Profile
    {
        public ModelsToResource()
        {
            CreateMap<Score, ScoresDTO>()
                .ForMember(destination => destination.User,
                conf => conf.MapFrom(source => source.User));
        }
    }
}
