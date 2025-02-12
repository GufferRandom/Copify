using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Copify.Service;
using Microsoft.AspNetCore.Mvc;
namespace Copify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController:ControllerBase
    {       
        private readonly ISpotifyAccountService _spotifyAccountService;
        public HomeController(ISpotifyAccountService spotifyAccountService){
            _spotifyAccountService=spotifyAccountService;
        }
    [HttpGet("/api/Home/testing")]
    public  async Task<IActionResult> testing(){
            string client_id = Environment.GetEnvironmentVariable("ClientId") ?? "";
            string client_secret = Environment.GetEnvironmentVariable("ClientSecret") ?? "";
            if (string.IsNullOrEmpty(client_id) || string.IsNullOrEmpty(client_secret))
            {
                throw new Exception("Environment variables are not set or are empty.");
            }
            var token = await _spotifyAccountService.GetToken(client_id, client_secret);
            return Ok(token); 

        }
    }
}