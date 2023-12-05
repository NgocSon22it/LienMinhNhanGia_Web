using DTOs.AccountDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Obj_Common;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;
using Web_Client.Models;

namespace Web_Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient client = null;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            client = new HttpClient();
            var contentType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Add(contentType);
        }


        public IActionResult Index()
        {

            return View();
        }

        public IActionResult HowToPlay()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]        
        public async Task<IActionResult> Login(Login login)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(Route.Login, login);

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("ErrorMessage", "Tên đăng nhập hoặc mật khẩu không hợp lệ.");
                return View(login);
            }

            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            Tokens tokens = JsonSerializer.Deserialize<Tokens>(strData, options);

            var CookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true
            };

            Response.Cookies.Append("access", tokens.Access_Token, CookieOptions);
            Response.Cookies.Append("refresh", tokens.Refresh_Token, CookieOptions);

            HttpContext.Session.SetString("Avatar", tokens.Avatar);
            HttpContext.Session.SetString("Role", tokens.Role.ToString());

            if (tokens.Role == Role.Admin) return RedirectToAction("Index", "HomeAdmin", new { area = "Admin" });

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(Register register)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(Route.Register, register);

            string strData = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                ModelState.AddModelError("ErrorMessage", strData.Replace("\"",""));
                return View(register);
            }
            
            return RedirectToAction(nameof(Login));
        }


        public IActionResult Forgot()
        {
            return View();
        }

        public IActionResult Store()
        {
            return View();
        }


        public async Task<IActionResult> Profile()
        {
            string access = Request.Cookies["access"];
            string refresh = Request.Cookies["refresh"];

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);
            client.DefaultRequestHeaders.Add("refresh", refresh);

            HttpResponseMessage response = await client.GetAsync(Route.Profile);

            if (!response.IsSuccessStatusCode)
            {
                return View();
            }

            string strData = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };
            var profile = JsonSerializer.Deserialize<AccountProfile>(strData, options);

            new resetCookie().reset(_httpContextAccessor, response); /// store new access

            HttpContext.Session.SetString("Avatar", profile.Avatar);

            if (profile != null) { return View(profile);}

            return RedirectToAction(nameof(Logout)); /// khong định danh đc người dùng 
            
        }

        public async Task<IActionResult> UpdateProfile(UpdateProfile updateProfile)
        {
            string access = Request.Cookies["access"];
            string refresh = Request.Cookies["refresh"];

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access);
            client.DefaultRequestHeaders.Add("refresh", refresh);

            HttpResponseMessage response = await client.PutAsJsonAsync(Route.UpdateProfile, updateProfile);

            if (!response.IsSuccessStatusCode)
            {
                return View();
            }

            new resetCookie().reset(_httpContextAccessor, response);

            return RedirectToAction(nameof(Profile));
        }

        public IActionResult ChangePass()
        {

            return View();
        }

        public IActionResult Logout()
        {
            Response.Cookies.Delete("access");
            Response.Cookies.Delete("refresh");
            HttpContext.Session.Clear();

            return RedirectToAction(nameof(Index));
        }
    }
}
