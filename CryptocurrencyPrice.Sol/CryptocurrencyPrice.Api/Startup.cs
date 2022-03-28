using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CryptocurrencyPrice.Api.Helpers;
using CryptocurrencyPrice.Business.BO;
using CryptocurrencyPrice.Business.Interfaces;
using CryptocurrencyPrice.Coinmarketcap.BO;
using CryptocurrencyPrice.Coinmarketcap.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using AutoMapper.Configuration;
using Microsoft.OpenApi.Models;

namespace CryptocurrencyPrice.Api
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

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Pruebas .Net Core + Angular",
                    Description = "Consumo de servicio de Coinmarketcap y se expone información para front desarrollado en Angular",
                    Contact = new OpenApiContact
                    {
                        Name = "Nicolas Salinas Galindo (Linkin)",
                        Url = new Uri("https://www.linkedin.com/in/jnsalinasgo")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Github repositorio",
                        Url = new Uri("https://github.com/jnsalinas/nectest")
                    }
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                    .AllowAnyMethod()
                    .SetIsOriginAllowed((Host) => true)
                    .AllowCredentials();
                });
            });

            #region dependy inyecton
            services.AddTransient<ICryptocurrencyBO, CryptocurrencyBO>();
            services.AddTransient<ICoinmarketcapBO, CoinmarketcapBO>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("CorsPolicy");

            app.UseHttpsRedirection();

            app.UseRouting();

            app.ConfigureExceptionHandler();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
