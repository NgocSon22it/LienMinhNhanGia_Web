using AutoMapper;
using DataAccess.Models;
using DTOs.MonsterDTOs;

namespace AutoMapperServices.MonsterMapper
{
    public class MonsterProfiles : Profile
    {
        public MonsterProfiles()
        {
            CreateMap<Monster, ViewMonster>();
        }
    }
}
