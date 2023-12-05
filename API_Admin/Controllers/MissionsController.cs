using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using DataAccess.Models;
using AppServices.MissionRepo;
using Microsoft.AspNetCore.Authorization;

namespace API_Admin.Controllers
{
    [Route("api/Admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class MissionsController : ControllerBase
    {
        MissionRepositories MissionManager;

        public MissionsController(MissionRepositories missionManager)
        {
            MissionManager = missionManager;
        }

        [HttpPost]
        public IActionResult AddMission(Mission mission)
        {
            try
            {
                if (!MissionManager.AddMission(mission))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Add Mission fail!");
                return StatusCode((int)HttpStatusCode.OK, "Add Mission success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateMission(Mission updateMission)
        {
            try
            {
                if (!MissionManager.UpdateMission(updateMission))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Update Mission fail!");
                return StatusCode((int)HttpStatusCode.OK, "Update Mission success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpDelete("{missionId}")]
        public IActionResult DeleteMission(string missionId)
        {
            try
            {
                if (!MissionManager.DeleteMission(missionId))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Delete Mission fail!");
                return StatusCode((int)HttpStatusCode.OK, "Delete Mission success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

    }
}
