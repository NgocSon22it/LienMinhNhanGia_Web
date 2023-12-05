﻿using DataAccess.Models;
using DTOs.ItemDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Obj_Common;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Web_Client.Areas.Admin.Controllers
{
    public class AbilityAdminController : Controller
    {
        private readonly HttpClient client = null;

        public AbilityAdminController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public async Task<IActionResult> Index()
        {
            //jwt 
            //access luwu thoong tin nguoi dung
            //refresh cap lai access
            string access = Request.Cookies["access"];
            string refresh = Request.Cookies["refresh"];

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);
            client.DefaultRequestHeaders.Add("refresh", refresh);


            HttpResponseMessage response = await client.GetAsync(Route.getAllAbility);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Ability> bosses = JsonSerializer.Deserialize<List<Ability>>(strData, options);

            return View(bosses);
        }

        public IActionResult Add()
        {
            return View();
        }


        public async Task<Ability> GetByID(string id)
        {
            string access = Request.Cookies["access"];
            string refresh = Request.Cookies["refresh"];

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);
            client.DefaultRequestHeaders.Add("refresh", refresh);


            HttpResponseMessage response = await client.GetAsync(String.Format(Route.getByIDAbility, id));
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Ability ability = JsonSerializer.Deserialize<Ability>(strData, options);

            return ability;
        }

        public async Task<IActionResult> Update(string id)
        {
            var ability = await GetByID(id);
            return View(ability);
        }
    }
}
