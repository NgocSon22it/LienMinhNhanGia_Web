using AutoMapper;
using DataAccess.Models;
using DTOs.CharacterDTOs;
using DTOs.SkillDTOs;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperServices.CharacterMapper
{
    public class CharacterProfiles : Profile
    {
        public CharacterProfiles()
        {
            CreateMap<Character, ViewCharacter>();

            CreateMap<Character, ViewCharacterInfo>();

            CreateMap<Character, ViewCharacterAdmin>();

            CreateMap<AccountCharacter, ViewCharacterAccountInfo>()
                .ForMember(viewCharacterAccount => viewCharacterAccount.Chakra,
                                    opt => opt.MapFrom(src => src.ChakraBonus + src.Character.Chakra))
                .ForMember(viewCharacterAccount => viewCharacterAccount.Health, 
                                    opt => opt.MapFrom(src => src.HealthBonus + src.Character.Health));
        }

    }
}
