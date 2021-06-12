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
using System.Linq;
using System.Threading.Tasks;

namespace Projekt_Notatki
{
   
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public class NotatkiContextFactory : IDesignTimeDbContextFactory<NotatkiContext>
        {
            public NotatkiContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<NotatkiContext>();
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-72RU6OQ3\SQLEXPRESS;Initial Catalog=Projekt-Notatki;Integrated Security=True");
                return new NotatkiContext(optionsBuilder.Options);
            }

        }
        public class UzytkownikContextFactory : IDesignTimeDbContextFactory<UzytkownikContext>
        {
            public UzytkownikContext CreateDbContext(string[] args)
            {
                var optionsBuilder = new DbContextOptionsBuilder<UzytkownikContext>();
                optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-72RU6OQ3\SQLEXPRESS;Initial Catalog=Projekt-Notatki;Integrated Security=True");
                return new UzytkownikContext(optionsBuilder.Options);
            }

        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NotatkiContext>(
             options => options.UseSqlServer("name=DefaultConnection:connectionString"));

            services.AddDbContext<UzytkownikContext>(
            options => options.UseSqlServer("name=DefaultConnection:connectionString"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Projekt_Notatki", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
