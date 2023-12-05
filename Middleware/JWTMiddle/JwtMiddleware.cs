using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using AppServices.JWTRepo;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Obj_Common;

namespace Middleware.JWTMiddle
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly JWTRepositories jWTManager;

        public JwtMiddleware(RequestDelegate next, JWTRepositories jWTManager)
        {
            _next = next;
            this.jWTManager = jWTManager;
        }

        public void ReturnUnauthorized(HttpContext context) {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return;
        }

        public async Task Invoke(HttpContext context)
        {
            var accessToken = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (accessToken == null) ReturnUnauthorized(context);

            try
            {
                Payload data = new Payload();

                // Validate the access token
                var accessToken_isValid = jWTManager.ValidateToken(accessToken, out data);

                // Access token has expired
                if (!accessToken_isValid)
                {
                    var refreshToken = context.Request.Headers["refresh"].FirstOrDefault();
                    if (refreshToken == null) ReturnUnauthorized(context);

                    // Validate the refresh token
                    Payload refreshToken_data = new Payload();
                    var refreshToken_isValid = jWTManager.ValidateToken(refreshToken, out refreshToken_data);

                    if (!refreshToken_isValid) ReturnUnauthorized(context);
                   
                    var newAccessToken = jWTManager.GenerateAccessToken(data);
                    context.Request.Headers["Authorization"] = "Bearer " + newAccessToken;

                    context.Response.Headers.Add("Access-Control-Expose-Headers", "access");
                    context.Response.Headers.Add("access", newAccessToken);
                }        
            }
            catch (Exception)
            {
                context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return;
            }
            
            await _next(context);
        }
    }

}
