using AuthServer.Data;
using AuthServer.SignalRHubs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthServer.Configuration;
using IdentityModel;

namespace AuthServer
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AuthServer", Version = "v1" });
            });

            services.AddDbContext<AuthServerDbContext>(options =>
                 options.UseSqlServer("Server=sql.bsite.net\\MSSQL2016;Database=liveserver_Databse;pwd=Password01;user Id=liveserver_Databse;MultipleActiveResultSets=true"));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
             .AddEntityFrameworkStores<AuthServerDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "Cookies";
                options.DefaultChallengeScheme = "oidc";
            }).AddCookie("Cookies")
             .AddOpenIdConnect("oidc", options =>
             {
                 options.Authority = AppSettings.AuthorityUrl;
                 options.SignInScheme = "Cookies";
                 options.RequireHttpsMetadata = false;
                 options.ClientId = AppSettings.ClientId;
                 options.ClientSecret = AppSettings.ClientSecret;
                 options.ResponseType = "code";
                 options.SaveTokens = true;
                 options.Scope.Add("openid");
                 options.Scope.Add("profile");
                 options.Scope.Add("email");
                 options.Scope.Add("role");
                 options.TokenValidationParameters = new TokenValidationParameters()//Maps properties from jwtClaims
                 {
                     NameClaimType = JwtClaimTypes.Email,
                     RoleClaimType = JwtClaimTypes.Role
                 };
             });
            services.AddSignalR();
            services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder
                .AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowed(origin => true)
                .AllowCredentials();
            }));
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AuthServer v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapHub<signInConnection>("/signInConnection");
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

        }
    }
}
