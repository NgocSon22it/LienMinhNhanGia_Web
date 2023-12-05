using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System;
using Obj_Common;
using DTOs.CharacterDTOs;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Linq;

namespace Web_Client.Controllers
{
    public class CharacterController : Controller
    {
        private readonly HttpClient client = null;

        public CharacterController()
        {
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }

        public async Task<IActionResult> Index(string? keyword, int page = 1, int pageSize = 10)
        {
            var url = Route.getAllCharacter;
            if (keyword != null) url += "?keyword=" + keyword;
            HttpResponseMessage response = await client.GetAsync(url);


            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            List<ViewCharacter> characters = JsonSerializer.Deserialize<List<ViewCharacter>>(strData, options);

            if (characters.Count > 0)
            {

                var totalCount = characters.Count();

                var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

                var data = characters.Skip((page - 1) * pageSize).Take(pageSize).ToList();

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
            HttpResponseMessage response = await client.GetAsync(String.Format(Route.getByIDCharacter, Id));
            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            ViewCharacterInfo character = JsonSerializer.Deserialize<ViewCharacterInfo>(strData, options);
            return View(character);
        }
    }
}
