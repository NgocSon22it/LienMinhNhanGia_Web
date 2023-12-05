using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System;
using AppServices.CharacterRepo;
using DTOs.CharacterDTOs;

namespace API_Common.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        CharacterRepositories CharacterManager;

        public CharactersController(CharacterRepositories characterManager)
        {
            CharacterManager = characterManager;
        }

        [HttpGet]
        public IActionResult GetAllCharacter(int? total, string? keyword)
        {
            try
            {
                return StatusCode((int)HttpStatusCode.OK, CharacterManager.GetAllCharacter<ViewCharacter>(total, keyword));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpGet("{characterId}")]
        public IActionResult GetCharacterbyID(string characterId)
        {
            try
            {
                var character = CharacterManager.GetCharacterbyID(characterId);
                if (character == null)
                    return StatusCode((int)HttpStatusCode.BadRequest, "Character does not exists");
                return StatusCode((int)HttpStatusCode.OK, character);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
