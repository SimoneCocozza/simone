using AcademyWebAPI.Model;
using AcademyWebAPI.Repository;
using AcademyWebAPI.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcademyWebAPI
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
            services.AddSingleton<IRepository<Student>, StudentRepository>();
            services.AddSingleton<IRepository<Exam>, ExamRepository>();
            services.AddSingleton<StudentService>();

            services.AddSwaggerGen(x => { x.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { 
                Title = "AcademyAPI",
                Version = "v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            /*
            app.Use(async (context, next) =>
            {
                Console.WriteLine("Prima del run");
                // Do work that doesn't write to the Response.
                await next.Invoke();
                // Do logging or other work that doesn't write to the Response.
                Console.WriteLine("Dopo il run");
            });

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Hello, World!");
            });
            */

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();

            app.UseSwaggerUI(x => { x.SwaggerEndpoint("/swagger/v1/swagger.json", "AcademyAPI"); } );

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
