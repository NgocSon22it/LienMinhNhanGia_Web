using AutoMapper;
using DataAccess.Models;
using DTOs.SkillDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperServices.SkillMapper
{
    public class SkillProfiles : Profile
    {
        public SkillProfiles() 
        { 
            CreateMap<Skill, ViewSkillInfo>();
            CreateMap<AccountSkill, ViewSkillAccountInfo>()
                .ForMember(viewSkillAccount => viewSkillAccount.SkillId,
                            opt => opt.MapFrom(src => src.SkillId))

                .ForMember(viewSkillAccount => viewSkillAccount.Name,
                            opt => opt.MapFrom(src => src.Skill.Name))

                .ForMember(viewSkillAccount => viewSkillAccount.Chakra,
                            opt => opt.MapFrom(src => src.Skill.Chakra))

                .ForMember(viewSkillAccount => viewSkillAccount.Damage,
                            opt => opt.MapFrom(src => src.Skill.Damage))

                .ForMember(viewSkillAccount => viewSkillAccount.Coin,
                            opt => opt.MapFrom(src => src.Skill.Coin))

                .ForMember(viewSkillAccount => viewSkillAccount.CurrentLevel,
                            opt => opt.MapFrom(src => src.CurrentLevel))

                .ForMember(viewSkillAccount => viewSkillAccount.Description,
                            opt => opt.MapFrom(src => src.Skill.Description))

                .ForMember(viewSkillAccount => viewSkillAccount.LinkImage,
                            opt => opt.MapFrom(src => src.Skill.LinkImage))

                ;
        }
    }
}
