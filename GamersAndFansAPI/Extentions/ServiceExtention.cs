using System.Text;
using Entities.Context;
using Entities.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;


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


    }
}
