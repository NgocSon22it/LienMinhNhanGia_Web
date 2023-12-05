using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using AppServices.AbilityRepo;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;

namespace API_Player.Controllers
{
    [Route("api/Player/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class AbilitiesController : ControllerBase
    {
        AbilityRepositories AbilityManager;

        public AbilitiesController(AbilityRepositories abilityManager)
        {
            AbilityManager = abilityManager;
        }

        [HttpGet]
        public IActionResult GetAbilitybyAccount()
        {
            try
            {
                string id = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;
                var abilities = AbilityManager.GetAbilitybyAccount(int.Parse(id));

                if (abilities == null)
                    return StatusCode((int)HttpStatusCode.BadRequest, "Ability does not exists.");

                return StatusCode((int)HttpStatusCode.OK, abilities);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

    }
}
