using DTOs.MonsterDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using AppServices.SkillRepo;
using DataAccess.Models;

namespace API_Common.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        SkillRepositories SkillManager;

        public SkillsController(SkillRepositories skillManager)
        {
            SkillManager = skillManager;
        }

        //unity call
        [HttpGet]
        public IActionResult GetAllSkill()
        {
            try
            {
                return StatusCode((int)HttpStatusCode.OK, SkillManager.GetAllSkill());
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        //unity call
        [HttpGet("{skillID}")]
        public IActionResult GetSkillbyID(string skillID)
        {
            try
            {
                var skill = SkillManager.GetSkillbyID(skillID);
                if (skill == null)
                    return StatusCode((int)HttpStatusCode.BadRequest, "Skill does not exists");

                return StatusCode((int)HttpStatusCode.OK, skill);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
