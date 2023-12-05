using Microsoft.AspNetCore.Http;
using Obj_Common;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Web_Client.Models
{
    public class resetCookie
    {
       
        public async Task reset(IHttpContextAccessor httpContextAccessor, HttpResponseMessage response)
        {
            var access = response.Headers.GetValues("Authorization").FirstOrDefault();
            httpContextAccessor.HttpContext.Response.Cookies.Delete("access");

            var CookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true
            };

            httpContextAccessor.HttpContext.Response.Cookies.Append("access", access, CookieOptions);

            Console.WriteLine("end");
        }
    }
}
