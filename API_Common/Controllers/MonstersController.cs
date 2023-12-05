using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using AppServices.MonsterRepo;
using DTOs.MonsterDTOs;

namespace API_Common.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MonstersController : ControllerBase
    {
        MonsterRepositories MonsterManager;

        public MonstersController(MonsterRepositories monsterManager)
        {
            MonsterManager = monsterManager;
        }


       
        [HttpGet]
        public IActionResult GetAllMonster(int? total, string? keyword, bool isPlaying = false)
        {
            try
            {
                return StatusCode((int)HttpStatusCode.OK, MonsterManager.GetAllMonster<ViewMonster>(total, keyword, isPlaying));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        //unity call
        [HttpGet("{monsterId}")]
        public IActionResult GetMonsterbyID(string monsterId)
        {
            try
            {
                var monster = MonsterManager.GetMonsterbyID(monsterId);
                if (monster == null) 
                    return StatusCode((int)HttpStatusCode.BadRequest, "Monster does not exists");
                return StatusCode((int)HttpStatusCode.OK, monster);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
