using AutoMapper;
using Entities.Models;
using Entities.DataTransfareObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contract;
using Entities.DataTransfareObjects.Retrive;

namespace GamersAndFansAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly IMapper Mapper;
        readonly ILoggerManager Logger;
        private readonly UserManager<User> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;
        private readonly IAuthenticationManager AuthenticationManager;

        public AccountController(IMapper mapper,ILoggerManager logger,UserManager<User>userManager,RoleManager<IdentityRole> roleManager,
                                  IAuthenticationManager authenticationManager)
        {
            Mapper = mapper;
            Logger = logger;
            UserManager = userManager;
            RoleManager = roleManager;
            AuthenticationManager = authenticationManager;

        }

        
        
        /// <summary>
        /// Registration based on user type 
        /// </summary>
        /// <remarks> Send the User Details with required fields , and remember the password must be atleast 8 characters including upper and lower case with numbers and special characters</remarks>
        /// <param name="registerUserDTO">Like a container mapped to the right model to send spacific properties</param>
        /// <returns>IAction Resault </returns>
        /// <response code="201">Ok Created</response>
        /// <response code="500">Internal Server Error</response>
        /// <response code="307">Temparary Redirection</response>
        [HttpPost]
        public async Task<IActionResult>RegisterUsre([FromBody]RegisterUserDTO registerUserDTO)
        {
            var user = Mapper.Map<User>(registerUserDTO);
            var resualt = await UserManager.CreateAsync(user, registerUserDTO.Password);
            if (!resualt.Succeeded)
            {
                foreach(var error in resualt.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);

                }
                return BadRequest(ModelState);
            }
            await UserManager.AddToRoleAsync(user, registerUserDTO.Roles);
            var regiteredUser = Mapper.Map<User,UserDTO>(user);
            

            return StatusCode(201, regiteredUser);
           
        }

        /// <summary>
        /// Sending a request with mail and password to get authentication bearer token
        /// </summary>
        /// <param name="user">User Details </param>
        /// <returns>Access token valid for a month with a user profile details</returns>
        /// <response code="200">Ok and return the access token with user profile </response>
        /// <response code="401">Un autherized if username or password not found </response>
        /// <response code="404">Not Found if the request URL is incorrect </response>
        /// <response code="500">Internal Server Error , If they are internal error , in this case the error message will be send to server log </response>
        [HttpPost("Login")]

        public async Task<IActionResult> Authenticate([FromBody]LoginDTO user)
        {
            
            if(!await AuthenticationManager.ValidateUser(user))
            {
                Logger.LogInfo($"{nameof(Authenticate)}:Login faild .. Wrong Username or Password .");
                return Unauthorized();
            }

            try
            {
                var User = await AuthenticationManager.GetUserProfile(user);
                var userProfile = Mapper.Map<User, UserDTO>(User);

                return Ok(new { Token = await AuthenticationManager.CreateToken(), userProfile });
            }
            catch(Exception ex)
            {
                Logger.LogError($"Something went wrong {ex}");
            }
            return BadRequest();
        }

    }
}
