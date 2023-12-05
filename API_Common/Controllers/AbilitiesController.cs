using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using AppServices.AbilityRepo;

namespace API_Common.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AbilitiesController : ControllerBase
    {
        AbilityRepositories AbilityManager;

        public AbilitiesController(AbilityRepositories abilityManager)
        {
            AbilityManager = abilityManager;
        }


        [HttpGet]
        public IActionResult GetAllAbility(int? total, string? keyword)
        {
            try
            {
                return StatusCode((int)HttpStatusCode.OK, AbilityManager.GetAllAbility(total, keyword));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpGet("{abilityId}")]
        public IActionResult GetAbilitybyID(string abilityId)
        {
            try
            {
                var ability = AbilityManager.GetAbilitybyID(abilityId);
                if (ability == null)
                    return StatusCode((int)HttpStatusCode.BadRequest, "Ability does not exists");

                return StatusCode((int)HttpStatusCode.OK, ability);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

    }
}
