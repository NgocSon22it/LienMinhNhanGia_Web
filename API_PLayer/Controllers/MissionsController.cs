using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System;
using AppServices.MissionRepo;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;
using DataAccess.Models;

namespace API_Player.Controllers
{
    [Route("api/Player/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class MissionsController : ControllerBase
    {
        MissionRepositories MissionManager;

        public MissionsController(MissionRepositories missionManager)
        {
            MissionManager = missionManager;
        }
       
        //unity call
        [HttpPost("{missionID}")]
        public IActionResult AddMissionToAccount(string missionID)
        {
            try
            {
                string id = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;

                var accountMission = new AccountMission();
                accountMission.AccountId = int.Parse(id);
                accountMission.MissionId = missionID;

                MissionManager.AddMissionToAccount(accountMission);

                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        //unity call
        [HttpGet]
        public IActionResult GetAllMissionForAccount()
        {
            try
            {
                string id = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;

                List<AccountMission> missions = MissionManager.GetAllMissionForAccount(int.Parse(id));

                return StatusCode((int)HttpStatusCode.OK, missions);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }
        
        //unity call
        [HttpPut("{missionID}/{state}")]
        public IActionResult UpdateAccountMissionState(string missionID, int state)
        {
            try
            {
                string id = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;

                var accountMission = new AccountMission();
                accountMission.AccountId = int.Parse(id);
                accountMission.MissionId = missionID;
                accountMission.State = state;

                MissionManager.UpdateAccountMissionState(accountMission);

                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        //unity call
        [HttpPut("{missionID}")]
        public IActionResult UpdateAccountMissionCurrent(string missionID)
        {
            try
            {
                string id = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;

                MissionManager.UpdateAccountMissionCurrent(int.Parse(id), missionID);

                return StatusCode((int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        //unity call
        [HttpGet("{missionID}")]
        public IActionResult GetAccountMissionByMissionID(string missionID)
        {
            try
            {
                string id = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;

                AccountMission missions = MissionManager.GetAccountMissionByMissionID(int.Parse(id), missionID);

                return StatusCode((int)HttpStatusCode.OK, missions);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }
    }
}
