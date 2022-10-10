using Headless.Core.Managers;
using Headless.Core.Payloads;
using Headless.DB.Tables;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Headless.API.Controllers.BE
{
    [Route("api/be/[controller]")]
    [ApiController]
    public class CustomFormsController : ControllerBase
    {
        private ICustomFormManager CustomFormManager { get; set; }
        public CustomFormsController(ICustomFormManager customFormManager)
        {
            CustomFormManager = customFormManager;
        }

        // GET: api/be/<CustomFormController>
        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                return Ok(await CustomFormManager.GetCustomForms());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/be/<CustomFormController>/5
        [HttpGet("{id}/data")]
        [Authorize]
        public async Task<ActionResult> GetFormData(Guid id)
        {
            try
            {
                List<string> data = await CustomFormManager.GetCustomFormData(id);
                return Ok(data);

                //return Content(data, "text/json");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(Guid id)
        {
            try
            {
                CustomForm form = await CustomFormManager.GetCustomForm(id);
                return Ok(form);

            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // POST api/be/<CustomFormController>
        [HttpPost]
        [Authorize]

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
