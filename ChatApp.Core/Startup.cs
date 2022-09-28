using System.Text;
using System.Threading.Tasks;
using ChatApp.Core.Hubs;
using ChatApp.Core.Services.Impl;
using ChatApp.Core.Services.Interfaces;
using ChatApp.Data;
using ChatApp.Data.Interfaces;
using ChatApp.Domain.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace ChatApp.Core
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
            services.AddDbContext<ChatDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            byte[] clientSecretKey = Encoding.ASCII.GetBytes(Configuration["ClientSecret"]);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(clientSecretKey),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
                x.Events = new JwtBearerEvents
                {
                    OnTokenValidated = context =>
                    {
                        context.HttpContext.User = context.Principal;
                        return Task.CompletedTask;
                    }
                };
            });


            //services
            //    .AddAuthorization()
            //    .AddAuthentication("Bearer")
            //    .AddJwtBearer("Bearer", options =>
            //    {
            //        options.Authority = Configuration["Authority"];
            //        options.RequireHttpsMetadata = false;
            //        options.Audience = Configuration["Audience"];
            //    });

            //services.AddAuthorization();

            services.AddCors(setup =>
            {
                //setup.AddDefaultPolicy(policy =>
                //{
                //    policy
                //    .AllowAnyOrigin()
                //        .AllowAnyHeader()
                //        .AllowAnyMethod()
                //        .AllowAnyOrigin();
                //});

                setup.AddPolicy("DefaultPolicy", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });


            services.AddControllersWithViews();
            services.AddControllers();
            services.AddRazorPages();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddSignalR();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors("DefaultPolicy");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.Use(async (context, next) =>
            {

                if (context.Request.Cookies["token"] != null)
                {
                    string token = context.Request.Cookies["token"];
                    if (context.Request.Headers.ContainsKey("Authorization") == false)
                    {
                        context.Request.Headers.Add("Authorization", "Bearer " + token);
                    }
                }
                await next();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
                endpoints.MapHub<ChatHub>("/chat");
            });
        }
    }
}
