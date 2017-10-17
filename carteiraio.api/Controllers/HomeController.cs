using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CarteiraIO.Api.Controllers
{
    public class HomeController : Controller
    {  
        public IActionResult Get()
        {
            return Ok(new { Oi = "Eu sou o Carteira.IO"});
        }
    }
}
