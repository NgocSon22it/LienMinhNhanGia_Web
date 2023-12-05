using DataAccess.Models;
using DTOs.BossDTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
    public class BossController : Controller
    {
        private readonly HttpClient client = null;

        public BossController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public async Task<IActionResult> Index(string? keyword, int page = 1, int pageSize = 10)
        {
            //call api get list boss
            var url = Route.getAllBoss;
            if (keyword != null) url += "?keyword=" + keyword;
            HttpResponseMessage response = await client.GetAsync(url);
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<ViewBoss> bosses = JsonSerializer.Deserialize<List<ViewBoss>>(strData, options);

            if (bosses.Count > 0)
            {
                //read json data
                var totalCount = bosses.Count();

                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var data = bosses.Skip((page - 1) * pageSize).Take(pageSize).ToList();

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
            //get data detail
            HttpResponseMessage response = await client.GetAsync(String.Format(Route.getByIDBoss, Id));
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Boss boss = JsonSerializer.Deserialize<Boss>(strData, options);
            return View(boss);
        }
    }
}
