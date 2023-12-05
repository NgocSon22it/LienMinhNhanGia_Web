using AutoMapper;
using DataAccess.Models;
using DTOs.BossDTOs;
using DTOs.MonsterDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapperServices.BossMapper
{
    public class BossProfiles : Profile
    {
        public BossProfiles()
        {
            CreateMap<Boss, ViewBoss>();
        }
    }
}
