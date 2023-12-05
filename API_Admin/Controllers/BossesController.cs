using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using DataAccess.Models;
using AppServices.BossRepo;
using Microsoft.AspNetCore.Authorization;
using DTOs.BossDTOs;

namespace API_Admin.Controllers
{
    [Route("api/Admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]

    public class BossesController : ControllerBase
    {

        BossRepositories BossManager;

        public BossesController(BossRepositories bossManager)
        {
            BossManager = bossManager;
        }

        [HttpGet]
        public IActionResult GetAllBoss()
        {
            try
            {
                return StatusCode((int)HttpStatusCode.OK, BossManager.GetAllBoss<Boss>(null, null, true));
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult AddBoss(Boss boss)
        {
            try
            {
                if (!BossManager.AddBoss(boss)) 
                    return StatusCode((int)HttpStatusCode.BadRequest, "Add Boss fail!");
                return StatusCode((int)HttpStatusCode.OK, "Add Boss success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateBoss(Boss updateBoss)
        {
            try
            {
                if (!BossManager.UpdateBoss(updateBoss)) 
                    return StatusCode((int)HttpStatusCode.BadRequest, "Update Boss fail!");
                return StatusCode((int)HttpStatusCode.OK, "Update Boss success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpDelete("{bossId}")]
        public IActionResult DeleteBoss(string bossId)
        {
            try
            {
                if (!BossManager.DeleteBoss(bossId)) 
                    return StatusCode((int)HttpStatusCode.BadRequest, "Delete Boss fail!");
                return StatusCode((int)HttpStatusCode.OK, "Delete Boss success");


            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

    }
}
