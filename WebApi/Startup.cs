using AutoMapper;
using Business.Services;
using Business.Services.Bases;
using Core.Business.Helpers.Security.Identity;
using Core.Business.Models.Security.Identity;
using Core.Business.Utils.Security.Identity;
using Core.Business.Utils.Security.Identity.Bases;
using Core.DataAccess.EntityFramework;
using Core.DataAccess.EntityFramework.Bases;
using DataAccess.Configs;
using DataAccess.EntityFramework;
using DataAccess.EntityFramework.Bases;
using DataAccess.EntityFramework.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Linq;
using System.Reflection;
using WebApi.Utils;

namespace WebApi
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
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());
            });

            var section = Configuration.GetSection("JwtOptions");
            JwtOptions jwtOptions = new JwtOptions();
            section.Bind(jwtOptions);
            var securityKeyHelper = new SecurityKeyHelper();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtOptions.Issuer,
                        ValidAudience = jwtOptions.Audience,
                        IssuerSigningKey = securityKeyHelper.CreateSecurityKey(jwtOptions.SecurityKey)
                    };
                });

            services.AddScoped<IOlayIhbarService, OlayIhbarService>();
            services.AddScoped<IFaaliyetService, FaaliyetService>();
            services.AddScoped<IIslemDurumuService, IslemDurumuService>();
            services.AddScoped<IOlayService, OlayService>();
            services.AddScoped<IPersonelService, PersonelService>();
            services.AddScoped<IIhbarDurumuService, IhbarDurumuService>();
            services.AddScoped<IIhbarService, IhbarService>();
            services.AddScoped<IKullaniciService, KullaniciService>();
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IAuthService, AuthService>();

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

            services.AddScoped<SqlBase, Sql>();

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            Config.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<DbContext, JkiContext>();

            services.AddSingleton<JwtUtilBase, JwtUtil>();

            //services.AddMvc(options =>
            //{
            //    options.OutputFormatters.Insert(3, new XmlDataContractSerializerOutputFormatter());
            //}).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //services.AddControllers(options => options.RespectBrowserAcceptHeader = true).AddXmlSerializerFormatters().AddXmlDataContractSerializerFormatters();

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jki API", Version = "v1" });
                //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jki API V1"));
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
