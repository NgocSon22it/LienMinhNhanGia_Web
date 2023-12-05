using DataAccess.Models;
using DTOs.MonsterDTOs;
using Microsoft.AspNetCore.Mvc;
using Obj_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace Web_Client.Controllers
{
    public class MonsterController : Controller
    {
        private readonly HttpClient client = null;

        public MonsterController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public async Task<IActionResult> Index(string? keyword, int page = 1, int pageSize = 10)
        {
            var url = Route.getAllMonster;
            if (keyword != null) url += "?keyword=" + keyword;
            HttpResponseMessage response = await client.GetAsync(url);

            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<ViewMonster> monsters = JsonSerializer.Deserialize<List<ViewMonster>>(strData, options);

            if (monsters.Count > 0)
            {
                var totalCount = monsters.Count();

                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var data = monsters.Skip((page - 1) * pageSize).Take(pageSize).ToList();

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
            HttpResponseMessage response = await client.GetAsync(String.Format(Route.getByIDMonster, Id));
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Monster monster = JsonSerializer.Deserialize<Monster>(strData, options);
            return View(monster);
        }
    }
}
