using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalGradeCalculator.Data;
using FinalGradeCalculator.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FinalGradeCalculator.Web
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
            services.AddCors();

            services.AddControllers();

            services.AddDbContext<FinalGradeCalculatorDbContext>(option => {
                option.EnableDetailedErrors();
                option.UseSqlServer(
                    Configuration.GetConnectionString("finalGradeCalculator.dev"),
                    b => b.MigrationsAssembly("FinalGradeCalculator.Web")
                );
            });

            //To make use of ICourseService
            services.AddScoped<ICourseService, CourseService>();

            //To add AspNetCore.Mvc.NewtonsoftJson
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //To allow external sites to make a request on this API
            //Cross-Origin Resource Sharing (CORS): https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS
            app.UseCors(builder => builder
                .WithOrigins(
                    "http://localhost:8080" //Might change the port
                )
                .AllowAnyMethod()
                .AllowAnyHeader()
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
