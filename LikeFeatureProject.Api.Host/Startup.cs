using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using LikeFeatureProject.Api.Host.DependencyInjection;
using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using LikeFeatureProject.Api.Respository.Database.Context;
using LikeFeatureProject.Api.Domain.Interfaces.Transactions;
using LikeFeatureProject.Api.Respository.Database.Transacions;

namespace LikeFeatureProject.Api.Host
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

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", builder => builder
                    .WithOrigins(new[] { "http://localhost:3000" })
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });

            services.AddControllers();

            services.AddSwaggerGen(c =>
             c.SwaggerDoc("v1",
                 new OpenApiInfo
                 {
                     Title = "Like Feature Porject",
                     Version = "v1",
                     Description = "Apis for a “Like” button feature created with ASP.NET Core ",
                     Contact = new OpenApiContact
                     {
                         Name = "Fabio Belther",
                         Url = new Uri("https://github.com/fabiobelther")
                     }
                 }));

            services.AddDbContext<LikeFeatureProjectContext>(opt =>
                opt.UseInMemoryDatabase("LikeFeatureProjectCDatabase")
            );

            services.AddScoped<LikeFeatureProjectContext, LikeFeatureProjectContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddServiceDependecies();

            services.AddMemoryCache();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
