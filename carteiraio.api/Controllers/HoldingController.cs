using Microsoft.AspNetCore.Mvc;

namespace CarteiraIO.Api.Controllers
{

    [Route("holding")]
    public class HoldingController : Controller
    {
        public HoldingController()
        {
            
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            return Ok(new { message = "Hello World"});
        }
    }
}
