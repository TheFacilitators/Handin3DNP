using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebServer.Interfaces;
using WebServer.Model;

namespace WebServer.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {

        private readonly IUserRepo userRepo;

        public AuthenticationController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpGet]
        public async Task<ActionResult<User>> ValidateUser([FromQuery] string username, [FromQuery] string password)
        {
            try
            {
                User user = await userRepo.ValidateUser(username, password);
                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}