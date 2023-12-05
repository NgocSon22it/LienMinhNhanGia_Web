using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Security.Claims;
using AppServices.ItemRepo;
using DataAccess.Models;
using DTOs.ItemDTOs;

namespace API_Player.Controllers
{
    [Route("api/Player/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ItemsController : ControllerBase
    {
        ItemRepositories ItemManager;

        public ItemsController(ItemRepositories itemManager)
        {
            ItemManager = itemManager;
        }

        //unity call
        [HttpGet]
        public IActionResult GetItembyAccount()
        {
            try
            {
                string id = User.Claims.FirstOrDefault(claim => claim.Type == ClaimTypes.Sid)?.Value;
                
                var viewItems = ItemManager.GetItembyAccount(int.Parse(id));

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
