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
using NLog;
using Repositories.IRepository;
using Repositories.Repository;
using System;
using System.IO;
using System.Reflection;

namespace GamersAndFansAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(),"/nlog.config"));
            Configuration = configuration;
           
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Gamers and Fans API",
                    Version = "v1",
                    Description = "Is a .Net5 API for registering Gamers and their Scores and registering Fans for KIONCM game. So the user can register credentials and the role then the API will response with a Status Code 201 that user created , in other hand they are three types of users (Gamer , Fan , Admin )",

                    Contact = new OpenApiContact
                    {
                        Name = "Osama Abu Baker",
                        Email = "Osamaabubaker111@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/osama-abu-baker/")

                    }
                    
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });

          
         
            

            services.AddDbContext<GamerDb>(
                 options => options.UseSqlServer(Configuration.GetConnectionString("sqlConnection")));

            services.AddScoped<ILoggerManager,LoggerManager>();
            services.AddScoped<IAuthenticationManager,AuthenticationManager>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
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
          
                
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "GamersAndFansAPI v1");
                c.RoutePrefix = string.Empty;
            });

            // Configure  Exception Middleware
            app.ConfigureExceptionHandler(logger);
            app.UseCors(x => x
             .AllowAnyOrigin()
             .AllowAnyMethod()
             .AllowAnyHeader());

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
