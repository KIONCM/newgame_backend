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

namespace GamersAndFansAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMapper Mapper;
        ILoggerManager Logger;
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

        [HttpGet]
        public List<IdentityRole> ListRoles()
        {
            return RoleManager.Roles.ToList();
        }

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
            return StatusCode(201);
        }


        [HttpPost("Login")]

        public async Task<IActionResult> Authenticate([FromBody]LoginDTO user)
        {
            if(!await AuthenticationManager.ValidateUser(user))
            {
                Logger.LogInfo($"{nameof(Authenticate)}:Login faild .. Wrong Username or Password .");
                return Unauthorized();
            }

            return Ok(new { Token = await AuthenticationManager.CreateToken() });
            
        }

    }
}
