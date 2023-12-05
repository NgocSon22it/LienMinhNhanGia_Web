using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using Microsoft.AspNetCore.Authorization;
using DataAccess.Models;
using AppServices.ItemRepo;

namespace API_Admin.Controllers
{
    [Route("api/Admin/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ItemsController : ControllerBase
    {
        ItemRepositories ItemManager;

        public ItemsController(ItemRepositories itemManager)
        {
            ItemManager = itemManager;
        }

        [HttpPost]
        public IActionResult AddItem(Item item)
        {
            try
            {
                if (!ItemManager.AddItem(item))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Add Item fail!");

                return StatusCode((int)HttpStatusCode.OK, "Add Item success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult UpdateItem(Item updateItem)
        {
            try
            {
                if (!ItemManager.UpdateItem(updateItem))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Update Item fail!");

                return StatusCode((int)HttpStatusCode.OK, "Update Item success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

        [HttpDelete("{itemId}")]
        public IActionResult DeleteItem(string itemId)
        {
            try
            {
                if (!ItemManager.DeleteItem(itemId))
                    return StatusCode((int)HttpStatusCode.BadRequest, "Delete Item fail!");

                return StatusCode((int)HttpStatusCode.OK, "Delete Item success");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

    }
}
