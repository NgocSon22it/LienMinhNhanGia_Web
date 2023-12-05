using AppServices.AbilityRepo;
using AppServices.AccountRepo;
using AppServices.BossRepo;
using AppServices.CharacterRepo;
using AppServices.ItemRepo;
using AppServices.JWTRepo;
using AppServices.MissionRepo;
using AppServices.MonsterRepo;
using AppServices.SkillRepo;
using AutoMapperServices.AccountMapper;
using AutoMapperServices.BossMapper;
using AutoMapperServices.CharacterMapper;
using AutoMapperServices.ItemMapper;
using AutoMapperServices.MissionMapper;
using AutoMapperServices.MonsterMapper;
using AutoMapperServices.SkillMapper;
using DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Middleware.JWTMiddle;
using System.Text;

namespace API_Admin
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddDbContext<LienminhnhangiaContext>();

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                var Key = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
                o.SaveToken = true;
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JWT:Issuer"],
                    ValidAudience = Configuration["JWT:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Key)
                };
            });

            services.AddTransient<JWTRepositories>();
            services.AddTransient<AccountRepositories>();
            services.AddTransient<ItemRepositories>();
            services.AddTransient<AbilityRepositories>();
            services.AddTransient<BossRepositories>();
            services.AddTransient<MissionRepositories>();
            services.AddTransient<MonsterRepositories>();
            services.AddTransient<CharacterRepositories>();
            services.AddTransient<SkillRepositories>();


            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile(new AccountProfiles());
                cfg.AddProfile(new ItemProfiles());
                cfg.AddProfile(new MissionProfiles());
                cfg.AddProfile(new SkillProfiles());
                cfg.AddProfile(new CharacterProfiles());
                cfg.AddProfile(new MonsterProfiles());
                cfg.AddProfile(new BossProfiles());
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_Admin", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_Admin v1"));
            }
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<JwtMiddleware>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
