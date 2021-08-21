
using Entities.DataTransfareObjects;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public class AuthenticationManager : IAuthenticationManager
    {
        // this class need to be simplify and applay SRP 
        private readonly UserManager<User> UserManager;
        private  User User;
        private IConfiguration Configuration;
        public AuthenticationManager(UserManager<User> userManager, IConfiguration configuration)
        {

            UserManager = userManager;
            Configuration = configuration;
        }
        public async Task<string> CreateToken()
        {
            var signingCredentials = GetSigningCredentials();
            var claims = await GetClaims();
            var tokenOptions = GenerateTokenOtopns(signingCredentials, claims);
            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }

        private JwtSecurityToken GenerateTokenOtopns(SigningCredentials signingCredentials, List<Claim> claims)
        {
            //var jwtSettings = Configuration.GetSection("JWTConfiguration");
            var tokenOptions = new JwtSecurityToken(
                //issuer: jwtSettings.GetSection("ValidIssuer").Value,
                issuer: Environment.GetEnvironmentVariable("VALID_ISSUER"),
                audience: Environment.GetEnvironmentVariable("VALID_AUDIENCE"),
                claims: claims,
                expires: DateTime.Now.AddDays(Convert.ToDouble(Environment.GetEnvironmentVariable("EXPIRES"))),
                signingCredentials: signingCredentials
                );

            return tokenOptions;
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, User.UserName) };
            var roles = await UserManager.GetRolesAsync(User);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }


        private SigningCredentials GetSigningCredentials()
        {
            var key =
                Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SECRET"));
            var secret = new SymmetricSecurityKey(key);
            return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
        }
        /// <summary>
        /// Check if user found the password matches user cradentials
        /// </summary>
        /// <param name="loginDTO">Passing login dto for mapping registeration details to model</param>
        /// <returns>bool of User Availability and password matching </returns>
        public async Task<bool> ValidateUser(LoginDTO loginDTO)
        {
            User = await UserManager.FindByNameAsync(loginDTO.Username);
            return (User != null && await UserManager.CheckPasswordAsync(User, loginDTO.Password));
        }

        public async Task<User> GetUserProfile(LoginDTO loginDTO)
        {
            return await UserManager.FindByNameAsync(loginDTO.Username);
            
        }
    }

}



