using Headless.Core.Managers;
using Headless.Core.Payloads;
using Headless.DB.Tables;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Headless.API.Controllers.BE
{
    [Route("api/be/[controller]")]
    [ApiController]
    public class CustomFormController : ControllerBase
    {
        private ICustomFormManager CustomFormManager { get; set; }
        public CustomFormController(ICustomFormManager customFormManager)
        {
            CustomFormManager = customFormManager;
        }

        // GET: api/be/<CustomFormController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/be/<CustomFormController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/be/<CustomFormController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CustomFormPL data)
        {
            try
            {
                CustomForm newCustomForm = await CustomFormManager.CreateCustomForm(data);
                return Ok(newCustomForm);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        // PUT api/be/<CustomFormController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/be/<CustomFormController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
