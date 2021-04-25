using BHA.ManagementAssistant.Nutritious.Common.Constant;
using BHA.ManagementAssistant.Nutritious.Core.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Model.Context;
using BHA.ManagementAssistant.Nutritious.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Model.Model.Entity;
using BHA.ManagementAssistant.Nutritious.Repository.Base;
using BHA.ManagementAssistant.Nutritious.Repository.Concrete;
using BHA.ManagementAssistant.Nutritious.Repository.Interface;
using BHA.ManagementAssistant.Nutritious.Service.Concrete;
using BHA.ManagementAssistant.Nutritious.Service.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace BHA.ManagementAssistant.Nutritious
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
            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore); //Tokenı Serialize edilemediği için reference loop hatasını engelliyor asp.net core 3.0 dan sonra json değişikliğiyle ilgili             

            services.AddDbContext<ManagementAssistantContext>(options => options.UseSqlServer(Connection.LocalConnectionString, migrations => migrations.MigrationsAssembly(Connection.DefaultMigrationLayer)));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = true,
                    ValidAudience = JwtConstants.HeaderTypeAlt,
                    ValidateIssuer = true,
                    ValidIssuer = JwtConstants.HeaderTypeAlt,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtConstants.JweCompactSerializationRegex))
                };
            });

            #region GetCurrentUser Getting
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddHttpContextAccessor();
            #endregion

            services.AddScoped<IRepository<Company>, MARepository<Company>>();
            services.AddScoped<IRepository<User>, MARepository<User>>();
            services.AddScoped<IRepository<Organization>, MARepository<Organization>>();
            services.AddScoped<IRepository<MenuElement>, MARepository<MenuElement>>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICompanyService, CompanyService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            //app.UseCustomMiddleware(); //CurrentUser yapısını değiştirdikten sonra custome bir middleware ihtiyacım kalmadı

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
