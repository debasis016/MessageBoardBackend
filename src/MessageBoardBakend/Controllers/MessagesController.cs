using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MessageBoardBakend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class MessagesController : Controller
    {
        //static List<Models.Message> messages = new List<Models.Message>{
        //        //new Models.Message
        //        //{
        //        //    Owner="Debasis1",
        //        //    Text="First Message"
        //        //},
        //        //new Models.Message
        //        //{
        //        //    Owner="Debasis2",
        //        //    Text="Second Text"
        //        //},
        //        //new Models.Message
        //        //{
        //        //    Owner="Debasis3",
        //        //    Text="Third Text"
        //        //}
        //    };

        readonly ApiContext context;
        public MessagesController(ApiContext context)
        {
            this.context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Models.Message> Get()
        {
            //return new string[] { "value1", "value2" };
            return context.Messages;
            
        }

        [HttpGet("{name}")]
        public IEnumerable<Models.Message> Get(string name)
        {
            //return new string[] { "value1", "value2" };
            return context.Messages.Where(message => message.Owner == name);

        }

        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        [HttpPost]
        public Models.Message Post([FromBody]Models.Message message)
        {
            var dbMessage = context.Messages.Add(message).Entity;
            context.SaveChanges();
            return dbMessage;
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
