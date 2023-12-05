using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using AppServices.AbilityRepo;
using Microsoft.AspNetCore.Authorization;
using DataAccess.Models;

namespace API_Admin.Controllers
{
    [Route("api/Admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AbilitiesController : ControllerBase
    {
        AbilityRepositories AbilityManager;

        public AbilitiesController(AbilityRepositories abilityManager)
        {
            AbilityManager = abilityManager;
        }

        [HttpPost]
        public IActionResult AddAbility(Ability ability)
        {
            try
            {
                if (!AbilityManager.AddAbility(ability)) 
                    return StatusCode((int)HttpStatusCode.BadRequest, "Add Ability fail!");
                
                return StatusCode((int)HttpStatusCode.OK, "Add Ability success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateAbility(Ability updateAbility)
        {
            try
            {
                if (!AbilityManager.UpdateAbility(updateAbility)) 
                    return StatusCode((int)HttpStatusCode.BadRequest, "Update Ability fail!");
               
                return StatusCode((int)HttpStatusCode.OK, "Update Ability success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpDelete("{abilityId}")]
        public IActionResult DeleteAbility(string abilityId)
        {
            try
            {
                if (!AbilityManager.DeleteAbility(abilityId)) 
                    return StatusCode((int)HttpStatusCode.BadRequest, "Delete Ability fail!");
                
                return StatusCode((int)HttpStatusCode.OK, "Delete Ability success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
