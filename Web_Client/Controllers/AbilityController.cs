using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Obj_Common;
using System.Linq;

namespace Web_Client.Controllers
{
    public class AbilityController : Controller
    {
        private readonly HttpClient client = null;

        public AbilityController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public async Task<IActionResult> Index(string? keyword, int page = 1, int pageSize = 10)
        {
            var url = Route.getAllAbility;
            if (keyword != null) url += "?keyword=" + keyword;
            HttpResponseMessage response = await client.GetAsync(url);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<Ability> abilities = JsonSerializer.Deserialize<List<Ability>>(strData, options);

            if (abilities.Count > 0)
            {
                //List<Ability> abilities = JsonSerializer.Deserialize<List<Ability>>(strData, options);
                var totalCount = abilities.Count();

                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var data = abilities.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                ViewData["TotalPages"] = totalPages;
                ViewData["CurrentPage"] = page;
                ViewData["PageSize"] = pageSize;
                ViewData["keyword"] = keyword;

                return View(data);
            }
            else
            {
                ViewData["message"] = "Không tìm thấy dữ liệu";
            }

            return View();
        }

        public async Task<IActionResult> GetbyID(string Id)
        {
            HttpResponseMessage response = await client.GetAsync(String.Format(Route.getByIDAbility, Id));
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Ability ability = JsonSerializer.Deserialize<Ability>(strData, options);
            return View(ability);
        }
    }
}
