using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace Copify.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HomeController:ControllerBase
    {       
    [HttpGet]
    public IActionResult testing(){
        List<int> listi= [1,2,3,4,5,6];
        
        return Ok(listi);
    }
    }
}