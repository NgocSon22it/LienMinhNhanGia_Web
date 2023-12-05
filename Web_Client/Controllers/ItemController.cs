using DataAccess.Models;
using DTOs.ItemDTOs;
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
    public class ItemController : Controller
    {
        private readonly HttpClient client = null;

        public ItemController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public async Task<IActionResult> Index(string? keyword, int page = 1, int pageSize = 10)
        {
            var url = Route.getAllItem;
            if (keyword != null) url += "?keyword=" + keyword;
            HttpResponseMessage response = await client.GetAsync(url);

            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<ViewItem> items = JsonSerializer.Deserialize<List<ViewItem>>(strData, options);

            if (items.Count > 0)
            {
                var totalCount = items.Count();

                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var data = items.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                ViewData["TotalPages"] = totalPages;
                ViewData["CurrentPage"] = page;
                ViewData["PageSize"] = pageSize;
                ViewData["keyword"] = keyword;
                return View(data);

            } else
            {
                ViewData["message"] = "Không tìm thấy dữ liệu";
            }

            return View();
        }

        public async Task<IActionResult> GetbyID(string Id)
        {
            HttpResponseMessage response = await client.GetAsync(String.Format(Route.getByIDItem, Id));
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            ViewItem item = JsonSerializer.Deserialize<ViewItem>(strData, options);
            return View(item);
        }
    }
}
