using AppServices.SkillRepo;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using Microsoft.AspNetCore.Authorization;

namespace API_Admin.Controllers
{
    [Route("api/Admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class SkillsController : ControllerBase
    {
        SkillRepositories SkillManager;

        public SkillsController(SkillRepositories skillManager)
        {
            SkillManager = skillManager;
        }

        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            try
            {
                if (!SkillManager.AddSkill(skill))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Add Skill fail!");
                return StatusCode((int)HttpStatusCode.OK, "Add Skill success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateSkill(Skill updateSkill)
        {
            try
            {
                if (!SkillManager.UpdateSkill(updateSkill))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Update Skill fail!");
                return StatusCode((int)HttpStatusCode.OK, "Update Skill success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpDelete("{skillId}")]
        public IActionResult DeleteSkill(string skillId)
        {
            try
            {
                if (!SkillManager.DeleteSkill(skillId))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Delete Skill fail!");
                return StatusCode((int)HttpStatusCode.OK, "Delete Skill success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
