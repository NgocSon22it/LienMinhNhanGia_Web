using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using DataAccess.Models;
using AppServices.MonsterRepo;
using Microsoft.AspNetCore.Authorization;
using DTOs.MonsterDTOs;

namespace API_Admin.Controllers
{
    [Route("api/Admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class MonstersController : ControllerBase
    {
        MonsterRepositories MonsterManager;

        public MonstersController(MonsterRepositories monsterManager)
        {
            MonsterManager = monsterManager;
        }

        [HttpGet]
        public IActionResult GetAllMonster()
        {
            try
            {
                return StatusCode((int)HttpStatusCode.OK, MonsterManager.GetAllMonster<Monster>(null, null, true));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddMonster(Monster monster)
        {
            try
            {
                if (!MonsterManager.AddMonster(monster))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Add Monster fail!");
                return StatusCode((int)HttpStatusCode.OK, "Add Monster success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateMonster(Monster updateMonster)
        {
            try
            {
                if (!MonsterManager.UpdateMonster(updateMonster))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Update Monster fail!");
                return StatusCode((int)HttpStatusCode.OK, "Update Monster success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpDelete("{monsterId}")]
        public IActionResult DeleteMonster(string monsterId)
        {
            try
            {
                if (!MonsterManager.DeleteMonster(monsterId))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Delete Monster fail!");
                return StatusCode((int)HttpStatusCode.OK, "Delete Monster success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

    }
}
