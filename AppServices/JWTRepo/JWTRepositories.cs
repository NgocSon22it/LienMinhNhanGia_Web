using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Obj_Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq;

namespace AppServices.JWTRepo
{
    public class JWTRepositories
    {
        IConfiguration Configuration { get; set; }
        //expAccessToken = 10 Minutes, expRefreshToken = 1 Day
        private readonly int expAccessToken = 10, expRefreshToken = 1;

        public JWTRepositories(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Tokens GenerateToken(Payload data)
        {
            string accessToken = GenerateAccessToken(data);
            string refreshToken = GenerateRefreshToken();
            return new Tokens
            {
                Access_Token = accessToken,
                Refresh_Token = refreshToken,
                Avatar = data.Avatar,
                Role = data.Role
            };
        }


        public string GenerateRefreshToken()
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Expires = DateTime.Now.AddDays(expRefreshToken),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public string GenerateAccessToken(Payload data)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenKey = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Sid, data.AccountId.ToString()),
                        new Claim(ClaimTypes.Role, data.Role.ToString()),
                    }),
                    Expires = DateTime.Now.AddMinutes(expAccessToken),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return tokenHandler.WriteToken(token);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool ValidateToken(string token, out Payload data)
        {
            try
            {
                var tokenKey = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
                var tokenHandler = new JwtSecurityTokenHandler();
                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(tokenKey)
                };

                SecurityToken validatedToken;
                var principal = tokenHandler.ValidateToken(token, validationParameters, out validatedToken);
                data = null;
                return true;
            }
            catch (SecurityTokenExpiredException ex)
            {
                // token has expired
                var handler = new JwtSecurityTokenHandler();
                var decodedToken = handler.ReadJwtToken(token);

                var sid = decodedToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Sid)?.Value;
                var role = decodedToken.Claims.FirstOrDefault(c => c.Type == "role")?.Value;
               
                data = new Payload
                {
                    AccountId = sid,
                    Role = (Role)Enum.Parse(typeof(Role), role)
                };

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
