using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using AppServices.CharacterRepo;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace API_Common.Controllers
{
    [Route("api/Player/[controller]/[action]")]
    [ApiController]
    [Authorize]

    public class CharactersController : ControllerBase
    {
        CharacterRepositories CharacterManager;

        public CharactersController(CharacterRepositories characterManager)
        {
            CharacterManager = characterManager;
        }

        [HttpGet]
        public IActionResult GetCharacterbyAccount()
        {
            try
            {
                string id = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;
                var viewItems = CharacterManager.GetAllCharacterbyAccount(int.Parse(id));

                if (viewItems == null) return StatusCode((int)HttpStatusCode.BadRequest, "Item does not exists.");

                return StatusCode((int)HttpStatusCode.OK, viewItems);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
