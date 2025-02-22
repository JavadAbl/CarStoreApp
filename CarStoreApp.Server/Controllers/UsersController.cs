using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarStoreApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetUsers()
        {
            return Ok(2);
        }
    }
}
