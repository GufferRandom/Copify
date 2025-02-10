using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Copify.AppliocatioDbContext;
using Copify.Dto;
using Copify.Mapper;
using Copify.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Copify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public AccountController(UserManager<AppUser> UserManager)
        {
            _userManager = UserManager;
        }
        [HttpPut]
        [ProducesResponseType(200,Type=typeof(RegisterDto))]
        public async Task<IActionResult> Register([FromBody] RegisterDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AppUser appUser = RegisterDtoToUser.ToAppUser(user);
            var res = await _userManager.CreateAsync(appUser, user.Password);
            if (res.Succeeded)
            {
                var RoleRes = await _userManager.AddToRoleAsync(appUser, "User");
                if (RoleRes.Succeeded)
                {
                    var response =new {Messege="User Created",User=user};
                    return Ok(response);
                }
                else
                {
                    return StatusCode(500, RoleRes.Errors);
                }
            }
            else
            {
                return StatusCode(500, res.Errors);
            }
        }
    }

}