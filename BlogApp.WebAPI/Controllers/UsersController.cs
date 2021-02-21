using BlogApp.Business.Interfaces;
using BlogApp.Business.Utility.AuthUtility;
using BlogApp.Entities.DTO.UserDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IAppUserService appUserService;
        private readonly IJwtService jwtService;

        public UsersController(IAppUserService appUserService, IJwtService jwtService)
        {
            this.appUserService = appUserService;
            this.jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserLoginDTO userLoginDTO)
        {
            var attemptedUser =  await appUserService.CheckOutUser(userLoginDTO);

            if (attemptedUser == null) return BadRequest("User credentials are invalid");

            Token jwtTOken = jwtService.BuildJwtToken(attemptedUser);

            return Created("", jwtTOken);

        }

        [HttpGet("[action]")]
        [Authorize]

        public async Task<IActionResult> ActiveUser()
        {
            var user = await appUserService.FindByUsername(User.Identity.Name);

            if (user == null) return BadRequest("No active user available");

            return Ok(new UserNameSurnameDto {Name = user.Name, Surname = user.Surname });
            
        }


    }
}
