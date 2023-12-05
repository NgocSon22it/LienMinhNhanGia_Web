using DTOs.CharacterDTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Obj_Common;
using DTOs.AccountDTOs;

namespace Web_Client.Areas.Admin.Controllers
{
    public class AccountAdminController : Controller
    {
        private readonly HttpClient client = null;


        public AccountAdminController()
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


            HttpResponseMessage response = await client.GetAsync(Route.getAllAccountAdmin);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<ViewAccountAdmin> accountAdmins = JsonSerializer.Deserialize<List<ViewAccountAdmin>>(strData, options);

            return View(accountAdmins);
        }

        public IActionResult Add()
        {

            return View();
        }


        public async Task<ViewAccountInfo> GetByID(string id)
        {
            string access = Request.Cookies["access"];
            string refresh = Request.Cookies["refresh"];

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);
            client.DefaultRequestHeaders.Add("refresh", refresh);


            HttpResponseMessage response = await client.GetAsync(String.Format(Route.detailAccount, id));
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            ViewAccountInfo accountInfo = JsonSerializer.Deserialize<ViewAccountInfo>(strData, options);

            return accountInfo;
        }

        public async Task<IActionResult> Detail(string id)
        {
            var accountInfo = await GetByID(id);
            return View(accountInfo);
        }
    }
}
  