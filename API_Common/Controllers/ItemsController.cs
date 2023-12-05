using Microsoft.AspNetCore.Mvc;
using System.Net;
using System;
using System.Collections.Generic;
using AutoMapper;
using DataAccess.Models;
using AppServices.ItemRepo;
using DTOs.ItemDTOs;

namespace API_Common.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        IMapper mapper;
        ItemRepositories ItemManager;

        public ItemsController(IMapper mapper, ItemRepositories itemManager)
        {
            this.mapper = mapper;
            ItemManager = itemManager;
        }

 
        [HttpGet]
        public IActionResult GetAllItem(int? total, string? keyword)
        {
            try
            {
                var items = ItemManager.GetAllItem(total, keyword);

                if(items.Count == 0) return StatusCode((int)HttpStatusCode.NoContent);

                var itemViews = mapper.Map<List<Item>, List<ViewItem>>(items);

                return StatusCode((int)HttpStatusCode.OK, itemViews);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }

    
        [HttpGet("{itemId}")]
        public IActionResult GetItembyID(string itemId)
        {
            try
            {
                var item = ItemManager.GetItembyID(itemId);
                
                if (item == null) 
                    return StatusCode((int)HttpStatusCode.BadRequest, "Item does not exists.");

                ViewItem itemView = mapper.Map<Item, ViewItem>(item);
                return StatusCode((int)HttpStatusCode.OK, item);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.NotFound, ex.Message);
            }
        }
        
    }
}
