using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using AppServices.MissionRepo;

namespace API_Common.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MissionsController : ControllerBase
    {
        MissionRepositories MissionManager;

        public MissionsController(MissionRepositories missionManager)
        {
            MissionManager = missionManager;
        }
       
        //unity call
        [HttpGet("{missionID}")]
        public IActionResult GetMissionbyId(string missionID)
        {
            try
            {
                var mission = MissionManager.GetMissionbyId(missionID);

                if (mission == null)
                    return StatusCode((int)HttpStatusCode.BadRequest, "Ability does not exists");

                return StatusCode((int)HttpStatusCode.OK, mission);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
