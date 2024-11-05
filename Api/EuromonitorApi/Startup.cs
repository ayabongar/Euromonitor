using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EuromonitorApi.Db; 

namespace EuromonitorApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers(); // Adds controller services
            services.AddScoped<Database>(); // Register the Database class for dependency injection

            services.AddSingleton<IConfiguration>(Configuration); // Makes configuration available across the app

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); // Developer-friendly error page in Development mode

                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Euromonitor API V1");
                   // c.RoutePrefix = string.Empty; 
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection(); // Redirects HTTP requests to HTTPS
            app.UseRouting(); // Configures request routing
            app.UseAuthorization(); // Enables authorization support

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Maps controller endpoints
            });
        }
    }
}
