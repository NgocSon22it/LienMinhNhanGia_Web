using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Obj_Common;

namespace Web_Client.Areas.Admin.Controllers
{
    public class BossAdminController : Controller
    {
        private readonly HttpClient client = null;

        public BossAdminController()
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


            HttpResponseMessage response = await client.GetAsync(Route.getAllBossAdmin);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Boss> bosses = JsonSerializer.Deserialize<List<Boss>>(strData, options);

           

            return View(bosses);
        }

        public IActionResult Add()
        {
            return View();
        }


        public async Task<Boss> GetByID(string id)
        {
            string access = Request.Cookies["access"];
            string refresh = Request.Cookies["refresh"];

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);
            client.DefaultRequestHeaders.Add("refresh", refresh);


            HttpResponseMessage response = await client.GetAsync(String.Format(Route.getByIDBoss, id));
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Boss accountInfo = JsonSerializer.Deserialize<Boss>(strData, options);

            return accountInfo;
        }

        public async Task<IActionResult> Update(string id)
        {
            var boss = await GetByID(id);
            return View(boss);
        }

        
    }
}
