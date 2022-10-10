using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Headless.API.Controllers.FE
{
    [Route("api/fe/[controller]")]
    [ApiController]
    public class CustomFormController : ControllerBase
    {
        // GET: api/<CustomFormController>
        [HttpGet("customFormName")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CustomFormController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CustomFormController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CustomFormController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CustomFormController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
