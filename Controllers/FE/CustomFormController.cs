using Headless.Core.Managers;
using Headless.DB.Tables;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Headless.API.Controllers.FE
{
    [Route("api/fe/[controller]")]
    [ApiController]
    public class CustomFormController : ControllerBase
    {
        private ICustomFormManager CustomFormManager { get; set; }
        public CustomFormController(ICustomFormManager customFormManager)
        {
            CustomFormManager = customFormManager;
        }
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

        // POST api/fe/<CustomFormController>
        [HttpPost("{formID}")]
        public async Task<ActionResult> PostData(Guid formID)
        {
            try
            {
                string jsonAsString;
                using (var reader = new StreamReader(Request.Body))
                {
                    jsonAsString = await reader.ReadToEndAsync();
                }
                CustomForm customForm = await CustomFormManager.GetCustomForm(formID);
                string result = await CustomFormManager.PostCustomFormData(customForm.FormName, jsonAsString);
                return Ok(result);
            }
            catch (Exception)
            {

                return BadRequest();
            }
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
