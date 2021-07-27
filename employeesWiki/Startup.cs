using employeesWiki.Shared;
using employeesWiki.StartupConfigs;
using employeesWiki.WikiDbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Linq;

namespace employeesWiki
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
            DependencyInjectionConfig.AddScoped(services);

            services.AddAutoMapper(typeof(Startup));

            services.AddCors(options => options.AddPolicy(Constants.DefaultCorsPolicyName, builder => builder.WithOrigins(
                            // App:CorsOrigins in appsettings.json can contain more than one address separated by comma.
                            Configuration["App:CorsOrigins"]
                                .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                .ToArray())
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials()
                )
            );

            services.AddControllers();
            services.AddDbContext<DbCtx>(x =>x.UseSqlServer(Configuration[Constants.ConnectionStringConfigName]));
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "employeesWiki", Version = "v1" });
            });

            services.AddLogging(config =>
            {
                config.AddDebug();
                config.AddConsole();
                //etc
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "employeesWiki v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors(Constants.DefaultCorsPolicyName);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}