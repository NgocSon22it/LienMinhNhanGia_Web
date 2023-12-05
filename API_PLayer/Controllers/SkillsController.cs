using AppServices.AbilityRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Net;
using System;
using AppServices.SkillRepo;
using System.Security.Claims;

namespace API_Player.Controllers
{
    [Route("api/Player/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class SkillsController : ControllerBase
    {
        SkillRepositories SkillManager;

        public SkillsController(SkillRepositories skillManager)
        {
            SkillManager = skillManager;
        }

        //unity call
        [HttpGet]
        public IActionResult GetSkillbyAccount()
        {
            try
            {
                string id = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;
                var skills = SkillManager.GetSkillbyAccount(int.Parse(id));

                if (skills == null)
                    return StatusCode((int)HttpStatusCode.BadRequest, "Skills does not exists.");

                return StatusCode((int)HttpStatusCode.OK, skills);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        //unity call
        [HttpGet("{slotIndex}")]
        public IActionResult GetAccountSkillbySlotIndex(int slotIndex)
        {
            try
            {
                string id = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;
                var skill = SkillManager.GetAccountSkillbySlotIndex(int.Parse(id), slotIndex);

                if (skill == null)
                    return StatusCode((int)HttpStatusCode.BadRequest, "Skills does not exists.");

                return StatusCode((int)HttpStatusCode.OK, skill);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        //unity call
        [HttpGet("{skillID}")]
        public IActionResult GetAccountSkillbySkillID(string skillID)
        {
            try
            {
                string id = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;
                var skill = SkillManager.GetAccountSkillbySkillID(int.Parse(id), skillID);
                
                if (skill == null)
                    return StatusCode((int)HttpStatusCode.BadRequest, "Skills does not exists.");

                return StatusCode((int)HttpStatusCode.OK, skill);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        //unity call
        [HttpPut("{skillID}/{slotIndex}")]
        public IActionResult UpdateAccountSkillSlotIndex(string skillID, int slotIndex)
        {
            try
            {
                string id = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;
                
                SkillManager.UpdateAccountSkillSlotIndex(int.Parse(id), skillID, slotIndex);

                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        //unity call
        [HttpPost("{skillID}")]
        public IActionResult BuySkill(string skillID)
        {
            try
            {
                string id = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;

                SkillManager.BuySkill(int.Parse(id), skillID);

                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        //unity call
        [HttpPut("{skillID}")]
        public IActionResult UpgradeAccountSkillLevel(string skillID)
        {
            try
            {
                string id = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;

                SkillManager.UpgradeAccountSkillLevel(int.Parse(id), skillID);

                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
