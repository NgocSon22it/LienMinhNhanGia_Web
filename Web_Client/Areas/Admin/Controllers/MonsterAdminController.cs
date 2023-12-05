using DTOs.AccountDTOs;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Obj_Common;
using DataAccess.Models;

namespace Web_Client.Areas.Admin.Controllers
{
    public class MonsterAdminController : Controller
    {
        private readonly HttpClient client = null;


        public MonsterAdminController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public async Task<IActionResult> Index()
        {
            string access = Request.Cookies["access"];
            string refresh = Request.Cookies["refresh"];

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);
            client.DefaultRequestHeaders.Add("refresh", refresh);


            HttpResponseMessage response = await client.GetAsync(Route.getAllMonsterAdmin);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Monster> monsterAdmins = JsonSerializer.Deserialize<List<Monster>>(strData, options);

            return View(monsterAdmins);
        }

        public IActionResult Add()
        {
            return View();
        }


        public async Task<Monster> GetByID(string id)
        {
            string access = Request.Cookies["access"];
            string refresh = Request.Cookies["refresh"];

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);
            client.DefaultRequestHeaders.Add("refresh", refresh);


            HttpResponseMessage response = await client.GetAsync(String.Format(Route.getByIDMonster, id));
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Monster accountInfo = JsonSerializer.Deserialize<Monster>(strData, options);

            return accountInfo;
        }

        public async Task<IActionResult> Update(string id)
        {
            var monster = await GetByID(id);
            return View(monster);
        }
    }
}
