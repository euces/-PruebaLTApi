using AutoMapper;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Serialization;
using Ventas.Common.Setting;
using Ventas.CrossCutting.EntityMapper;
using Ventas.CrossCutting.Helper;
using Ventas.Interface.Business;
using Ventas.Interface.Helpeer;
using Ventas.Interface.Repository;
using Ventas.Interface.Service;
using Ventas.Model.Model;
using Ventas.Repository.Repository;
using Ventas.Service.Business;
using Ventas.Service.Service;
using System;
using System.Text;

namespace Ventas.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddControllers(options =>
            {
                options.RespectBrowserAcceptHeader = true; // false by default
            }).AddNewtonsoftJson();

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                // Use the default property (Pascal) casing
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperDtoToModel());
                mc.AddProfile(new MapperModelToDto());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);


            var appJwtSection = Configuration.GetSection("Jwt");
            services.Configure<JwtSettings>(appJwtSection);


            // configure jwt authentication
            var appJwt = appJwtSection.Get<JwtSettings>();
            var key = Encoding.ASCII.GetBytes(appJwt.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            var connectionString = string.Empty;

            var azureKeyVault = Configuration.GetSection("AzureKeyVault");
            string keyVaultEndpoint = azureKeyVault["KeyVaultEndpoint"];
            if (!string.IsNullOrEmpty(keyVaultEndpoint))
            {
                SecretClientOptions options = new SecretClientOptions()
                {
                    Retry =
                {
                    Delay= TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                 }
                };

                var client = new SecretClient(new Uri(keyVaultEndpoint), new DefaultAzureCredential(), options);
                KeyVaultSecret secret = client.GetSecret(azureKeyVault["KeyVaultConnection"]);
                connectionString = secret.Value;
                services.Configure<ConnectionString>(d => d.PBSWoekshop = connectionString);
            }
            else
            {
                connectionString = Configuration.GetConnectionString("VentasConnection");
                services.Configure<ConnectionString>(d => d.PBSWoekshop = connectionString);
            }

            services.AddEntityFrameworkOracle().AddDbContext<VentasContext>(options =>
            {
                options.UseOracle(connectionString);
            });

            services.AddScoped<ITokenHelper, TokenHelper>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserBusiness, UserBusiness>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IFacturaService, FacturaService>();
            services.AddScoped<IFacturaBusiness, FacturaBusiness>();
            services.AddScoped<IFacturaRepository, FacturaRepository>();

            services.AddScoped<IProductoService, ProductoService>();
            services.AddScoped<IProductoBusiness, ProductoBusiness>();
            services.AddScoped<IProductoRepository, ProductoRepository>();

            AddSwagger(services);
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Ventas {groupName}",
                    Version = groupName,
                    Description = "Ventas API",
                    Contact = new OpenApiContact
                    {
                        Name = "Ventas",
                        Email = string.Empty,
                        Url = new Uri("https://foo.com/"),
                    }
                });
            });
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Ventas API V1");
            });
            app.UseRouting();
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });
        }
    }
}
