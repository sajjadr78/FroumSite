using FroumSite.Data;
using FroumSite.Models;
using FroumSite.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FroumSite
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
            services.AddControllersWithViews();

            #region Db Context

            //add-migrations needs microsoft.entityframeworkcore.tools package
            services.AddDbContext<FroumContext>(options =>
            {
                options
                .UseSqlServer(Configuration.GetConnectionString("LocalConnection"));
            });

            #endregion

            #region AddTransients

            services.AddScoped(typeof(GenericRepository<User>));
            services.AddScoped(typeof(GenericRepository<Topic>));
            services.AddScoped(typeof(GenericRepository<Room>));
            services.AddScoped(typeof(GenericRepository<Post>));
            services.AddScoped(typeof(GenericRepository<UserLikePost>));
            services.AddScoped(typeof(GenericRepository<UserLikeTopic>));

            services.AddScoped<IGenericRepository<Post>, GenericRepository<Post>>();
            services.AddScoped<IGenericRepository<Subject>, GenericRepository<Subject>>();
            services.AddScoped<IGenericRepository<Room>, GenericRepository<Room>>();
            services.AddScoped<IGenericRepository<Topic>, GenericRepository<Topic>>();
            services.AddScoped<IGenericRepository<User>, GenericRepository<User>>();

            //services.AddScoped<IGenericRepository<UserLikePost>, GenericRepository<UserLikePost>>();
            //services.AddScoped<IGenericRepository<UserLikeTopic>, GenericRepository<UserLikeTopic>>();

            #endregion

            #region Authentication

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(option =>
                {
                    option.LoginPath = "/Account/Login";
                    option.LogoutPath = "/Account/Logout";
                    option.ExpireTimeSpan = TimeSpan.FromDays(10);
                });

            #endregion

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
            app.Use(async (context, next) =>
            {
                // Do work that doesn't write to the Response.
                if (context.Request.Path.StartsWithSegments("/Boss"))
                {
                    if (!context.User.Identity.IsAuthenticated)
                    {
                        context.Response.Redirect("/Account/Login");
                    }
                    else if (!bool.Parse(context.User.FindFirstValue("IsAdmin")))
                    {
                        context.Response.Redirect("/Account/Login");
                    }
                }
                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
            });



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
