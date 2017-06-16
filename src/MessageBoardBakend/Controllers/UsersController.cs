using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MessageBoardBakend.Controllers
{
    [Produces("application/json")]
    [Route("api/Users")]
    public class UsersController : Controller
    {

        readonly ApiContext context;
        public UsersController(ApiContext context)
        {
            this.context = context;
        }

        [Authorize]
        [HttpGet("me")]
        public ActionResult Get()
        {
            var id = HttpContext.User.Claims.First().Value;
            return Ok(context.Users.SingleOrDefault(u => u.Id == id));
        }
        // GET: api/values
        [HttpGet("{id}")]
        public ActionResult Get(string id)
        {
            var user = context.Users.SingleOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound("User not found");
            }
            return Ok(user);
        }

        
    }
}
