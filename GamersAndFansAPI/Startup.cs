using Contract;
using Entities.Context;
using GamersAndFansAPI.Extentions;
using LoggerService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Repositories.IRepository;
using Repositories.Repository;
using System;

namespace GamersAndFansAPI
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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GamersAndFansAPI", Version = "v1" });
            });

            services.AddDbContext<GamerDb>(
                 options => options.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));

            services.AddScoped<ILoggerManager,LoggerManager>();
            services.AddScoped<IAuthenticationManager,AuthenticationManager>();

            services.AddScoped<IScoreRepository,ScoreRepository>();
            services.AddScoped<IScoreService,ScoreService>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.ConfigureIdentity();
            services.ConfigureJWT(Configuration);
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILoggerManager logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GamersAndFansAPI v1"));
            }

            // Configure  Exception Middleware
            app.ConfigureExceptionHandler(logger);
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
