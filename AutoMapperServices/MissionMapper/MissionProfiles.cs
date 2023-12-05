using AutoMapper;
using DataAccess.Models;
using DTOs.ItemDTOs;
using DTOs.MissionDTOs;

namespace AutoMapperServices.MissionMapper
{
    public class MissionProfiles : Profile
    {
        public MissionProfiles()
        {
            CreateMap<AccountMission, ViewMission>()
              .ForMember(viewMission => viewMission.Name,
                          opt => opt.MapFrom(src => src.Mission.Name))
              .ForMember(viewMission => viewMission.Category,
                          opt => opt.MapFrom(src => src.Mission.Category))
              .ForMember(viewMission => viewMission.Request,
                          opt => opt.MapFrom(src => src.Mission.Request))
              .ForMember(viewMission => viewMission.Target,
                          opt => opt.MapFrom(src => src.Mission.Target))
              .ForMember(viewMission => viewMission.ExperienceBonus,
                          opt => opt.MapFrom(src => src.Mission.ExperienceBonus))
              .ForMember(viewMission => viewMission.CoinBonus,
                          opt => opt.MapFrom(src => src.Mission.CoinBonus))
              .ForMember(viewMission => viewMission.State,
                          opt => opt.MapFrom(src => src.State));
        }
    }
}
