using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Copify.AppliocatioDbContext;
using Copify.Dto;
using Copify.Interfaces;
using Copify.Mapper;
using Copify.Models;
using Copify.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Copify.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> UserManager, ITokenService tokenService,SignInManager<AppUser> signInManager)
        {
            _userManager = UserManager;
            _tokenService=tokenService;
            _signInManager= signInManager;
        }

        [HttpGet("register")]
        public async Task<IActionResult> Register()
        {
            RegisterDto registerDto = new RegisterDto();

            return Ok(registerDto);
        }
        [HttpGet("login")]
        public async Task<IActionResult> Login()
        {
            LoginDto loginDto = new LoginDto();

            return Ok(loginDto);
        }
        [HttpPost("register")]
        [ProducesResponseType(200,Type=typeof(RegisterDto))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Register([FromBody] RegisterDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AppUser appUser = RegisterDtoToUser.ToAppUser(user);
            var checking = await _userManager.Users.FirstOrDefaultAsync(x=>x.Email == appUser.Email);
            if(checking != null)
            {
                Object respones = new { ErrorMesege = "Gmail Arleady Exist", Gmail = user.Gmail };
                return BadRequest(respones);
            }
            var res = await _userManager.CreateAsync(appUser, user.Password);
            if (res.Succeeded)
            {
                var RoleRes = await _userManager.AddToRoleAsync(appUser, "User");
                if (RoleRes.Succeeded)
                {
                    var response =new { Messege = "User Created", User = user };
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
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginDto login)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            AppUser user;
            if (login.UserNameOrGmail.EndsWith("@gmail.com", StringComparison.OrdinalIgnoreCase))
            {
                user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == login.UserNameOrGmail);
            }
            else
            {
                user = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == login.UserNameOrGmail);
            }
            if(user == null)
            {
                return Unauthorized("Invalid Username Or Invalid Email");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, login.Password,false);
            if(result.Succeeded)
            {
                var response = new
                {
                    Messege = "User Loged In",
                    User = new NewUserDto
                    {
                        Email=user.Email,
                        UserName = user.UserName,
                        Token = _tokenService.CreateToken(user)
                    }
                };
                return Ok(response);
            }
            else
            {
                return Unauthorized("Username not found Or Password Is Incorrect");
            }
        }
    }

}