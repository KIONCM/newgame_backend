using System;
using System.IO;
using System.Reflection;
using System.Text;
using Entities.Context;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;


namespace GamersAndFansAPI.Extentions
{
    public static class ServiceExtention
    {
        public static void ConfigureIdentity(this IServiceCollection service)
        {
            service.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
                options.Password.RequiredUniqueChars = 1;
            });

            service.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters=
                 "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_.";
                options.User.RequireUniqueEmail = false;
            });

            service.AddIdentity<User, IdentityRole>()
                    .AddEntityFrameworkStores<GamerDb>();
        }

        public static void ConfigureJWT(this IServiceCollection services,IConfiguration configuration)
        {
            var JWTSettings = configuration.GetSection("JWTConfiguration");
            services.AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = JWTSettings.GetSection("ValidIssuer").Value,
                        ValidAudience = JWTSettings.GetSection("ValidAudience").Value,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTSettings.GetSection("Secret").Value))
                    };
                });
        }

        public static void ConfigureSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Gamers and Fans API",
                    Version = "v1",
                    Description = "Is a .Net5 API for registering Gamers and their Scores and registering Fans for KIONCM game." +
                    " So the user can register credentials and the role then the API will " +
                    "response with a Status Code 201 that user created , " +
                    "in other hand they are three types of users (Gamer , Fan , Admin )",
                    
                    Contact = new OpenApiContact
                    {
                        Name = "Osama Abu Baker",
                        Email = "Osamaabubaker111@gmail.com",
                        Url = new Uri("https://www.linkedin.com/in/osama-abu-baker/")
                        
                    }
                    /*
                    ,
                    License = new OpenApiLicense
                    {
                        Name = "Employee API LICX",
                        Url = new Uri("https://example.com/license"),
                    }
                    */
                });
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
        }


    }
}
