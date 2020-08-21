using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Services;
using Business.Services.Bases;
using Business.Utils;
using Business.Utils.Bases;
using Core.Business.Utils;
using Core.Business.Utils.Bases;
using DataAccess.Configs;
using DataAccess.EntityFramework;
using DataAccess.EntityFramework.Bases;
using DataAccess.EntityFramework.Context;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.Models;
using Presentation.Settings;

namespace Presentation
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
            Config.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(config =>
                {
                    config.LoginPath = "/Kullanici/Login";
                    config.AccessDeniedPath = "/Kullanici/AccessDenied";
                });

            //services.AddDbContext<JkiContext>();
            services.AddScoped<DbContext, JkiContext>();
            services.AddScoped<IOlayIhbarService, OlayIhbarService>();
            services.AddScoped<IFaaliyetService, FaaliyetService>();
            services.AddScoped<IIslemDurumuService, IslemDurumuService>();
            services.AddScoped<IOlayService, OlayService>();
            services.AddScoped<IPersonelService, PersonelService>();
            services.AddScoped<IIhbarDurumuService, IhbarDurumuService>();
            services.AddScoped<IIhbarService, IhbarService>();
            services.AddScoped<IKullaniciService, KullaniciService>();
            services.AddScoped<IRolService, RolService>();

            services.AddScoped<OlayIhbarDalBase, OlayIhbarDal>();
            services.AddScoped<FaaliyetDalBase, FaaliyetDal>();
            services.AddScoped<IslemDurumuDalBase, IslemDurumuDal>();
            services.AddScoped<OlayDalBase, OlayDal>();
            services.AddScoped<PersonelDalBase, PersonelDal>();
            services.AddScoped<IhbarDurumuDalBase, IhbarDurumuDal>();
            services.AddScoped<IhbarDalBase, IhbarDal>();
            services.AddScoped<KullaniciDalBase, KullaniciDal>();
            services.AddScoped<RolDalBase, RolDal>();
            services.AddScoped<VW_OlayDalBase, VW_OlayDal>();
            // Auto Mapper Configurations
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            services.AddSession();

            services.AddScoped<TimeUtilBase, TimeUtil>();

            services.AddScoped<IControllerUtil, ControllerUtil>();


            services.AddControllersWithViews();
            services.Configure<RazorViewEngineOptions>(o =>
            {
                // {2} is area, {1} is controller,{0} is the action
                // the component's path "Components/{ViewComponentName}/{ViewComponentViewName}" is in the action {0}
                o.ViewLocationFormats.Add("/{0}" + RazorViewEngine.ViewExtension);
            });

            AppSettings appSettings = new AppSettings();
            var section = Configuration.GetSection("AppSettings");
            section.Bind(appSettings);
            //new SeedData(new JkiContext());
            //services.AddControllersWithViews().AddRazorRuntimeCompilation(); //launch.json dosyasýnda belirtildi.
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

            app.UseSession();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
