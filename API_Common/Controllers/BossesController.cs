using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using AppServices.BossRepo;
using DTOs.BossDTOs;

namespace API_Common.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BossesController : ControllerBase
    {
        BossRepositories BossManager;

        public BossesController(BossRepositories bossManager)
        {
            BossManager = bossManager;
        } 

       
        [HttpGet]
        public IActionResult GetAllBoss(int? total, string? keyword)
        {
            try
            {
                return StatusCode((int)HttpStatusCode.OK, 
                    BossManager.GetAllBoss<ViewBoss>(total, keyword));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

 
        [HttpGet("{bossId}")]
        public IActionResult GetBossbyID(string bossId)
        {
            try
            {
                var boss = BossManager.GetBossbyID(bossId);
                if (boss == null) 
                    return StatusCode((int)HttpStatusCode.BadRequest, "Boss does not exists");
                
                return StatusCode((int)HttpStatusCode.OK, boss);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
