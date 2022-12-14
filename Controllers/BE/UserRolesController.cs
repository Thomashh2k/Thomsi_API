using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Headless.API.Controllers.BE
{
    [Route("api/be/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        // GET: api/<UserRolesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserRolesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserRolesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<UserRolesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserRolesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
