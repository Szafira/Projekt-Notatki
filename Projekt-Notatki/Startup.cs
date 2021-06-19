using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Projekt_Notatki.Data.Migrations;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Notatki
{
   
    public class Startup
    {
        readonly string AllowOrigin = "_AllowOrigin";
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IConfiguration Configuration { get; }
    
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<NotatkiContext>(options =>
                options.UseSqlServer("name=DefaultConnection:connectionString"));

            services.AddDbContext<UzytkownikContext>(options =>
                options.UseSqlServer("name=DefaultConnection:connectionString"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Projekt_Notatki", Version = "v1" });
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: AllowOrigin,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:4200", "127.0.0.1:4200")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();

                                  });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Projekt_Notatki v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(AllowOrigin);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
