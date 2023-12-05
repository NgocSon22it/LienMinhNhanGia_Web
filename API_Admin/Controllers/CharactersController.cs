using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using AppServices.CharacterRepo;
using Microsoft.AspNetCore.Authorization;
using DataAccess.Models;
using DTOs.CharacterDTOs;

namespace API_Common.Controllers
{
    [Route("api/Admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class CharactersController : ControllerBase
    {
        CharacterRepositories CharacterManager;

        public CharactersController(CharacterRepositories characterManager)
        {
            CharacterManager = characterManager;
        }

        [HttpGet]
        public IActionResult GetAllCharacter()
        {
            try
            {
                return StatusCode((int)HttpStatusCode.OK, CharacterManager.GetAllCharacter<ViewCharacterAdmin>(null, null, true));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddCharacter(Character character)
        {
            try
            {
                if (!CharacterManager.AddCharacter(character)) 
                    return StatusCode((int)HttpStatusCode.BadRequest, "Add Character fail!");
                return StatusCode((int)HttpStatusCode.OK, "Add Character success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateCharacter(Character updateCharacter)
        {
            try
            {
                if (!CharacterManager.UpdateCharacter(updateCharacter)) 
                    return StatusCode((int)HttpStatusCode.BadRequest, "Update Character fail!");
                return StatusCode((int)HttpStatusCode.OK, "Update Character success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpDelete("{characterId}")]
        public IActionResult DeleteCharacter(string characterId)
        {
            try
            {
                if (!CharacterManager.DeleteCharacter(characterId)) 
                    return StatusCode((int)HttpStatusCode.BadRequest, "Delete Character fail!");
                return StatusCode((int)HttpStatusCode.OK, "Delete Character success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
