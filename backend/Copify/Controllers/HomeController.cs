using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Copify.Service;
using Microsoft.AspNetCore.Mvc;
using Copify.Service;
using Copify.Interfaces;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Copify.Dto;
using System.Collections.ObjectModel;
using System.Text.Json;
namespace Copify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly ISpotifyAccountService _spotifyAccountService;
        private readonly ISpotifyNewReleases _spotifyNewReleases;
        private readonly string client_id = Environment.GetEnvironmentVariable("ClientId") ?? "";
        private readonly string client_secret = Environment.GetEnvironmentVariable("ClientSecret") ?? "";
        public HomeController(ISpotifyAccountService spotifyAccountService,ISpotifyNewReleases spotifyNewReleases)
        {
            _spotifyAccountService = spotifyAccountService;
            _spotifyNewReleases=spotifyNewReleases;
        }
        [HttpGet("/api/Home/testing")]
        public async Task<IActionResult> testing()
        {
          
            if (string.IsNullOrEmpty(client_id) || string.IsNullOrEmpty(client_secret))
            {
                throw new Exception("Environment variables are not set or are empty.");
            }
            var token = await _spotifyAccountService.GetToken(client_id, client_secret);
            return Ok(token);

        }
        [HttpGet]

        public async Task<IActionResult> tesa(){
            string token = await _spotifyAccountService.GetToken(client_id,client_secret);
            var res =await _spotifyNewReleases.NewReleases("US",5,token);
            return Ok(res);
        }
    }
}